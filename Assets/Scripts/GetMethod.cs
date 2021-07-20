using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
 
public class GetMethod : MonoBehaviour
{
    InputField outputArea;
    InputField overview;
 
    void Start()
    {
        outputArea = GameObject.Find("OutputArea").GetComponent<InputField>();
        overview = GameObject.Find("Overview").GetComponent<InputField>();
        GameObject.Find("GetButton").GetComponent<Button>().onClick.AddListener(GetData);
    }
 
    void GetData() => StartCoroutine(GetData_Coroutine());
 
    IEnumerator GetData_Coroutine()
    {
        outputArea.text = "Loading...";
        overview.text = "Loading...";
        string uri = "http://50.66.79.240:4000/activities";

        using(UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError || webRequest.isHttpError)
            {
                Debug.Log("inside if");
                outputArea.text = webRequest.error;
                overview.text = webRequest.error;
            }
            else
            {
                outputArea.text = webRequest.downloadHandler.text;
                overview.text = webRequest.downloadHandler.text;
            }
        }
    }
}