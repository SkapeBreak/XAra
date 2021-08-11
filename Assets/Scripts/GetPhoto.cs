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

    JSONNode appliancesParse;

    void Start()
    {
        StartCoroutine(GetPhotoData());
    }

    IEnumerator GetPhotoData()
    {
        string uri = "http://50.66.79.240:4000/appliances";

        using(UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError || webRequest.isHttpError)
            {
                Debug.Log(webRequest.error);
            }
            else
            {
                appliancesParse = JSON.Parse(webRequest.downloadHandler.text);

                 for (int i = 0; i < appliancesParse["response"].Count; i++) 
                 {
                    string uriPhotos = "http://50.66.79.240:4000/" + appliancesParse["response"][i]["avatar"];

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