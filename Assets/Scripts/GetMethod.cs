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
        Debug.Log("Bug");
        
        outputArea.text = "Loading...";
        string uri = "http://50.66.79.240:4000/activities";

        using(UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError || webRequest.isHttpError)
            {
                Debug.Log("inside if");
                outputArea.text = webRequest.error;
            }
            else
            {
                outputArea.text = webRequest.downloadHandler.text;
            }
        }
    }
}