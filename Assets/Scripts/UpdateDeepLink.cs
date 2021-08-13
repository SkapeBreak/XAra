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
        string deeplinkID = "Unitydl://mylink?dryer";
        
        try
        {
            string manualName = deeplinkID.Split("?"[0])[1];
            StartCoroutine(GetManualData(manualName));
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message+" string missing '?' pls fix");
        }
        
    }

    IEnumerator GetManualData(string manualName)
    {
        // Debug.Log(manualName);
        string uri = $"http://50.66.79.240:4000/manuals";

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

                for (int i = 0; i < manualParse.Count; i++){
                
                // Debug.Log(i);
                // Debug.Log(manualParse[i][manualName+"name"]);
                
                    // Yay this works!
                    if(manualParse[i][manualName+"name"] != null)
                    {   
                        ManualCardTemplate.GetComponent<ManualButton>().SetManualName(manualParse[i][manualName+"name"]);
                        ManualCardTemplate.GetComponent<ManualButton>().SetManualBody(manualParse[i][manualName+"body"]);
                    }
                }
            }
        }
    } 
}