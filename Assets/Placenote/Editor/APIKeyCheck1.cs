#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEditor.Build;
using System.IO;
using System;


[CustomEditor(typeof(LibPlacenote1))]
public class LibPlacenote1Editor : Editor, IPreprocessBuild
{
	public int callbackOrder { get { return 0; } }
	string filePath;
	void OnEnable()
	{
		//File where APIKey gets written out in ever scene LibPlacenote1 is active
		string sceneName = EditorSceneManager.GetActiveScene ().name;
		filePath = Application.persistentDataPath
			+ @"/apikey_" + sceneName + ".dat";
	}

	public override void OnInspectorGUI()
	{
		//Called everytime PlacenoteCameraManager (and the attached LibPlacenote1 script) is touched. We write out the APIKey
		var lib = target as LibPlacenote1;
		DrawDefaultInspector ();
		StreamWriter writer = new StreamWriter (filePath, false);
		writer.WriteLine(lib.apiKey);
		writer.Close();
	}

	public void OnPreprocessBuild(BuildTarget target, string path) {

		//Check if LibPlacenote1 exists, active in the current scene
		bool libPlacenote1Exists = false;
		GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>() ;
		foreach (GameObject go in allObjects) {
			if (go.activeInHierarchy) {
				if (go.GetComponent (typeof(LibPlacenote1)) != null) {
					libPlacenote1Exists = true;
				}
			}
		}
			
		//Right before a build starts, read the APIKey that was entered in OnInspectorGUI and make sure its not blank. 
		//If LibPlacenote1 does exist, try to read the file. If its empty, error out. If it doesn't exist, error out. 
		if (libPlacenote1Exists) {
			if (File.Exists (filePath)) {
				StreamReader reader = new StreamReader (filePath);
				string keyRead = reader.ReadToEnd ();

				if (keyRead == null) {
					throw new Exception ("API Key Empty, Please get an API Key from http://developers.placenote.com and enter it under the LibPlacenote1 Object in the PlacenoteCameraManager");
				} else if (keyRead.Trim () == "") {
					throw new Exception("API Key Empty, Please get an API Key from http://developers.placenote.com and enter it under the LibPlacenote1 Object in the PlacenoteCameraManager");
				} else {
					Debug.Log ("API Key Entered:" + keyRead);
				}
				reader.Close ();
			} else {
				throw new Exception ("API Key Empty, Please get an API Key from http://developers.placenote.com and enter it under the LibPlacenote1 Object in the PlacenoteCameraManager");
			}
		}
	}
}
#endif

