using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
 
public class GetMethod : MonoBehaviour
{
    InputField outputArea;
 
    void Start()
    {
        outputArea = GameObject.Find("OutputArea").GetComponent<InputField>();
        GameObject.Find("GetButton").GetComponent<Button>().onClick.AddListener(GetData);
    }
 
    void GetData() => StartCoroutine(GetData_Coroutine());
 
    IEnumerator GetData_Coroutine()
    {
        outputArea.text = "Loading...";
        Debug.Log("trying to connect...");

        string uri = "https://localhost:3000/activities";
        
        Debug.Log("still trying to connect...");
        using(UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            Debug.Log("inside webRequest");
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError || webRequest.isHttpError)
            {
                outputArea.text = webRequest.error;
                Debug.Log("inside if");
            }
            else
            {
                outputArea.text = webRequest.downloadHandler.text;
                Debug.Log("inside else");
            }
        }
    }
}