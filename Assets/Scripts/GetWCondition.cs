using System.Collections;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using SimpleJSON;

public class GetWCondition : MonoBehaviour
{   
   InputField outputArea;

    void Start()
    {
        StartCoroutine(GetWeatherConditionData());
    }
  
    IEnumerator GetWeatherConditionData()
    {
        string uri = "https://api.openweathermap.org/data/2.5/weather?lat=51.056442&lon=-114.069333&units=metric&APPID=c24bbbe6090072b0f620ea57d0ce8764";
        outputArea = GameObject.Find("Condition").GetComponent<InputField>();

        using(UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();
            if (webRequest.isNetworkError|| webRequest.isHttpError)
            {
                Debug.Log(webRequest.error);
            } else
            {
                //var climate = JsonConvert.DeserializeObject<weatherResponse>(webRequest.downloadHandler.text);
                JSONNode climate = JSON.Parse(webRequest.downloadHandler.text);
                //Debug.Log(climate["weather"][0]["description"]);
                outputArea.text = climate["weather"][0]["description"];
            }
        }
    }        
}