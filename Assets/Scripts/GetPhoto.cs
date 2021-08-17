using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using System.Collections.Generic;
using SimpleJSON;
using System;

public class GetPhoto : MonoBehaviour
{
    [SerializeField] private GameObject photoCardTemplate;

    JSONNode photoParse;

    void Start()
    {
        StartCoroutine(GetPhotoData());
    }

    IEnumerator GetPhotoData()
    {
        string uri = "http://localhost:5000/guest-book";

        using(UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError || webRequest.isHttpError)
            {
                Debug.Log(webRequest.error);
            }
            else
            {
                photoParse = JSON.Parse(webRequest.downloadHandler.text);

                 for (int i = 0; i < photoParse["response"].Count; i++) 
                 {
                     if (photoParse["response"][i]["suiteId"] == PersistentManager.Instance.currentSuiteId)
                    {
                        string uriPhotos = "http://localhost:5000/" + photoParse["response"][i]["avatar"];

                        using(UnityWebRequest photoRequest = UnityWebRequestTexture.GetTexture(uriPhotos))
                        {
                            yield return photoRequest.SendWebRequest();

                            if (photoRequest.isNetworkError || photoRequest.isHttpError)
                            {
                                Debug.Log(photoRequest.error);
                            }
                            else
                            {
                                var photoTexture = DownloadHandlerTexture.GetContent(photoRequest);

                                GameObject photoCard = Instantiate(photoCardTemplate) as GameObject;

                                photoCard.SetActive(true);

                                photoCard.GetComponent<RawImage>().texture = photoTexture;

                                photoCard.transform.SetParent(photoCardTemplate.transform.parent, false);
                            }
                        }
                    }
                 }
            }
        }
    } 
}