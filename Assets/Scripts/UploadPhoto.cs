using UnityEngine;
using System.Text;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.UI;
using SimpleJSON;
using System;
 
public class UploadPhoto : MonoBehaviour {
    
    public InputField userNameInputField;
    public InputField emailInputField;
    public InputField passwordInputField;
    public InputField phoneNumberInputField;
    
    void Start() {
        
        userNameInputField = GameObject.Find("InputField1").GetComponent<InputField>();
        emailInputField = GameObject.Find("InputField2").GetComponent<InputField>();
        passwordInputField = GameObject.Find("InputField3").GetComponent<InputField>();
        phoneNumberInputField = GameObject.Find("InputField4").GetComponent<InputField>();        
        GameObject.Find("PostButton").GetComponent<Button>().onClick.AddListener(PostData);
    }

       
    void PostData() 
    {
        UserData data = new UserData();
        // data.userName = userNameInputField.text;
        // data.email = emailInputField.text;
        // data.password = passwordInputField.text;
        // data.phoneNumber = phoneNumberInputField.text;
        string json = JsonUtility.ToJson(data, true);    
        
        StartCoroutine(PostData_Coroutine("http://xaramyhost.tk:4000/users", json));
    }
     
    IEnumerator PostData_Coroutine(string url, string bodyJsonString) 
    {
        
        var request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(bodyJsonString);
        request.uploadHandler = (UploadHandler) new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.Send();

        Debug.Log("Status Code: " + request.responseCode);

    }
}