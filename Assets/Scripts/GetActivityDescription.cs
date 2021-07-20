using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections.Generic;
using SimpleJSON;

public class GetActivityDescription : MonoBehaviour
{
    InputField descriptionArea;

    void Start()
    {
        StartCoroutine(GetDescriptionData());
    }

    IEnumerator GetDescriptionData()
    {
        descriptionArea = GameObject.Find("DescriptionArea").GetComponent<InputField>();
        string uri = "http://localhost:3000/activities/";

        using(UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError || webRequest.isHttpError)
            {
                descriptionArea.text = webRequest.error;
            }
            else
            {
                JSONNode activitiesParse = JSON.Parse(webRequest.downloadHandler.text);

                for (int i = 0; i < activitiesParse.Count; i++) 
                {
                    descriptionArea.text = activitiesParse[i]["description"];
                }
            }
        }
    }
}