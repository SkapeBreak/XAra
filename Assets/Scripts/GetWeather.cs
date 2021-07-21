using System.Collections;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GetWeather : MonoBehaviour
{
   
   InputField outputArea;

 
    void Start()
    {
        outputArea = GameObject.Find("OutputAreaWeather").GetComponent<InputField>();
        GameObject.Find("GetWeather").GetComponent<Button>().onClick.AddListener(GetData);
    }
 
    void GetData() => StartCoroutine(GetData_Coroutine());
 
    IEnumerator GetData_Coroutine()
    {
        string uri = "https://api.openweathermap.org/data/2.5/weather?lat=51.056442&lon=-114.069333&units=metric&APPID=c24bbbe6090072b0f620ea57d0ce8764";

        using(UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();
        if (webRequest.isNetworkError|| webRequest.isHttpError)
        {
            Debug.Log(webRequest.error);
        }else
        {
            var weather = JsonConvert.DeserializeObject<weatherResponse>(webRequest.downloadHandler.text);

            //temperature = GameObject.Find("Text").GetComponent<Text>();
            outputArea.text = weather.main.temp.ToString();
            Debug.Log("let me click");

        }
        }
    }        
}






