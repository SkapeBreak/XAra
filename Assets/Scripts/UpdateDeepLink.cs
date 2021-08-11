using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using System.Collections.Generic;
using SimpleJSON;
using System;

[RequireComponent(typeof(Text))]
public class UpdateDeepLink : MonoBehaviour
{
    JSONNode manualParse;
    [SerializeField] private GameObject ManualCardTemplate;


    private void Start()
    {
        //Get Deep link value from global deeplink manager
        var label = GetComponent<Text>();
        // string deeplinkID = ProcessDeepLinkMngr.Instance.deeplinkURL;
        string deeplinkID = "unitydl://mylink?1";
        
        string manualName = deeplinkID.Split("?"[0])[1];
        StartCoroutine(GetManualData(manualName));
    }

    IEnumerator GetManualData(string manualName)
    {
        Debug.Log(manualName);
        string uri = $"https://jsonplaceholder.typicode.com/posts/{manualName}";

        using(UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError || webRequest.isHttpError)
            {
                Debug.Log(webRequest.error);
            }
            else
            {
                manualParse = JSON.Parse(webRequest.downloadHandler.text);

                // Debug.Log(manualParse);

                // Yay this works!
                ManualCardTemplate.GetComponent<ManualButton>().SetManualName(manualParse.ToString());

                // for( int i = 0; i < 1; i++)
                // {
                //     GameObject manualCard = Instantiate(ManualCardTemplate) as GameObject;

                //     manualCard.GetComponent<ManualButton>().SetManualName(manualParse);
                // } 
            }
        }
    } 
}
