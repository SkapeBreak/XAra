using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.XR.iOS;
using System.Runtime.InteropServices;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

public class ReadMap : MonoBehaviour, PlacenoteListener1 {

    private const string MAP_NAME = "GenericMap";

    private UnityARSessionNativeInterface mSession;
    private bool mFrameUpdated = false;
    private UnityARImageFrameData1 mImage = null;
    private UnityARCamera mARCamera;
    private bool mARKitInit = false;

    private LibPlacenote1.MapMetadataSettable mCurrMapDetails;

    private bool mReportDebug = false;

    string currMapID = String.Empty;

    private LibPlacenote1.MapInfo mSelectedMapInfo;
    private string mSelectedMapId {
        get {
            return mSelectedMapInfo != null ? mSelectedMapInfo.placeId : null;
        }
    }

    // Use this for initialization
    void Start() {
        Input.location.Start();

        mSession = UnityARSessionNativeInterface.GetARSessionNativeInterface();
        UnityARSessionNativeInterface.ARFrameUpdatedEvent += ARFrameUpdated;
        StartARKit();
        FeaturesVisualizer1.EnablePointcloud();
        LibPlacenote1.Instance.RegisterListener(this);
    }

    void OnDisable() {
        UnityARSessionNativeInterface.ARFrameUpdatedEvent -= ARFrameUpdated;
    }

    private void ARFrameUpdated(UnityARCamera camera) {
        mFrameUpdated = true;
        mARCamera = camera;
    }

    private void InitARFrameBuffer() {
        mImage = new UnityARImageFrameData1();

        int yBufSize = mARCamera.videoParams.yWidth * mARCamera.videoParams.yHeight;
        mImage.y.data = Marshal.AllocHGlobal(yBufSize);
        mImage.y.width = (ulong)mARCamera.videoParams.yWidth;
        mImage.y.height = (ulong)mARCamera.videoParams.yHeight;
        mImage.y.stride = (ulong)mARCamera.videoParams.yWidth;

        // This does assume the YUV_NV21 format
        int vuBufSize = mARCamera.videoParams.yWidth * mARCamera.videoParams.yWidth / 2;
        mImage.vu.data = Marshal.AllocHGlobal(vuBufSize);
        mImage.vu.width = (ulong)mARCamera.videoParams.yWidth / 2;
        mImage.vu.height = (ulong)mARCamera.videoParams.yHeight / 2;
        mImage.vu.stride = (ulong)mARCamera.videoParams.yWidth;

        mSession.SetCapturePixelData(true, mImage.y.data, mImage.vu.data);
    }

    // Update is called once per frame
    void Update() {
        if (mFrameUpdated) {
            mFrameUpdated = false;
            if (mImage == null) {
                InitARFrameBuffer();
            }

            if (mARCamera.trackingState == ARTrackingState.ARTrackingStateNotAvailable) {
                // ARKit pose is not yet initialized
                return;
            } else if (!mARKitInit && LibPlacenote1.Instance.Initialized()) {
                mARKitInit = true;
                Debug.Log("ARKit Initialized: LOADING MAP!!!!!");
                FindMap();
            }

            Matrix4x4 matrix = mSession.GetCameraPose();

            Vector3 arkitPosition = PNUtility1.MatrixOps.GetPosition(matrix);
            Quaternion arkitQuat = PNUtility1.MatrixOps.GetRotation(matrix);

            LibPlacenote1.Instance.SendARFrame(mImage, arkitPosition, arkitQuat, mARCamera.videoParams.screenOrientation);
        }
    }

    void FindMap() {
        //get metadata
        LibPlacenote1.Instance.SearchMaps(MAP_NAME, (LibPlacenote1.MapInfo[] obj) => {
            foreach (LibPlacenote1.MapInfo map in obj) {
                if (map.metadata.name == MAP_NAME) { //check if it is the same name
                    mSelectedMapInfo = map;
                    Debug.Log("FOUND MAP: " + mSelectedMapInfo.placeId);
                    LoadMap();
                    return;
                }
            }
        });
    }

    void LoadMap() {
        ConfigureSession(false);

        LibPlacenote1.Instance.LoadMap(mSelectedMapInfo.placeId,
            (completed, faulted, percentage) => {
                if (completed) {

                    if (mReportDebug) {
                        LibPlacenote1.Instance.StartRecordDataset(
                            (datasetCompleted, datasetFaulted, datasetPercentage) => {

                                if (datasetCompleted) {
                                    Debug.Log("Dataset Upload Complete");
                                } else if (datasetFaulted) {
                                    Debug.Log("Dataset Upload Faulted");
                                } else {
                                    Debug.Log("Dataset Upload: " + datasetPercentage.ToString("F2") + "/1.0");
                                }
                            });
                        Debug.Log("Started Debug Report");
                    }

                    Debug.Log("Loaded ID: " + mSelectedMapInfo.placeId + "...Starting session");

                    LibPlacenote1.Instance.StartSession(true);

                } else if (faulted) {
                    Debug.Log("Failed to load ID: " + mSelectedMapInfo.placeId);
                } else {
                    Debug.Log("Map Download: " + percentage.ToString("F2") + "/1.0");
                }
            }
        );
    }

    private void StartARKit() {
        Debug.Log("Initializing ARKit");
        Application.targetFrameRate = 60;
        ConfigureSession(false);
    }

    private void ConfigureSession(bool clearPlanes) {
#if !UNITY_EDITOR
		ARKitWorldTrackingSessionConfiguration config = new ARKitWorldTrackingSessionConfiguration ();
		config.planeDetection = UnityARPlaneDetection.None;
		config.alignment = UnityARAlignment.UnityARAlignmentGravity;
		config.getPointCloudData = true;
		config.enableLightEstimation = true;
		mSession.RunWithConfig (config);
#endif
    }

    public void OnPose(Matrix4x4 outputPose, Matrix4x4 arkitPose) { }

    public void OnStatusChange(LibPlacenote1.MappingStatus prevStatus, LibPlacenote1.MappingStatus currStatus) {
        Debug.Log("prevStatus: " + prevStatus.ToString() + " currStatus: " + currStatus.ToString());
        if (currStatus == LibPlacenote1.MappingStatus.RUNNING && prevStatus == LibPlacenote1.MappingStatus.LOST) {
            Debug.Log("Localized: " + mSelectedMapInfo.metadata.name);
            GetComponent<CustomShapeManager>().LoadShapesJSON(mSelectedMapInfo.metadata.userdata);
            FeaturesVisualizer1.DisablePointcloud();
        } else if (currStatus == LibPlacenote1.MappingStatus.RUNNING && prevStatus == LibPlacenote1.MappingStatus.WAITING) {
            Debug.Log("Mapping");
        } else if (currStatus == LibPlacenote1.MappingStatus.LOST) {
            Debug.Log("Searching for position lock");
        } else if (currStatus == LibPlacenote1.MappingStatus.WAITING) {
            if (GetComponent<CustomShapeManager>().shapeObjList.Count != 0) {
                //GetComponent<CustomShapeManager>().ClearShapes();
            }
        }
    }
}
