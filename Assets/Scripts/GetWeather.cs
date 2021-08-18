using System.Collections;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using SimpleJSON;
using System;

public class GetWeather : MonoBehaviour
{   
   public Text weatherTemp;
   public Text weatherCondition;

    void Start()
    {
        StartCoroutine(GetWeatherConditionData());
    }
  
    IEnumerator GetWeatherConditionData()
    {
        string uri = "https://api.openweathermap.org/data/2.5/weather?lat=51.056442&lon=-114.069333&units=metric&APPID=c24bbbe6090072b0f620ea57d0ce8764";

        using(UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();
            if (webRequest.isNetworkError|| webRequest.isHttpError)
            {
                Debug.Log(webRequest.error);
            } else
            {
                JSONNode climate = JSON.Parse(webRequest.downloadHandler.text);

                weatherCondition.text = climate["weather"][0]["description"] + "  |";
                weatherTemp.text = (climate["main"]["temp"]).ToString().Split("."[0])[0] + "°C";
            }
        }
    }        
}