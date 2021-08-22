using UnityEngine;
using System.Text;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.UI;
using SimpleJSON;
using System;
 
public class SignGuestbook : MonoBehaviour {
    
    public InputField commentInput;
    public GameObject guestbookCanvas;
    public GameObject signGuestbook;
    public GameObject fileBrowser;

    public void SignGuestbookOnClick()
    {
        signGuestbook.SetActive(false);
        guestbookCanvas.SetActive(true);
    }

    public void CloseSignGuestbookOnClick()
    {
        guestbookCanvas.SetActive(false);
        signGuestbook.SetActive(true);
    }

    public void AttachPhoto()
    {
        fileBrowser.SetActive(true);
    }
       
    public void PostData() 
    {
        UserData data = new UserData();
        data.userName = commentInput.text;
        string json = JsonUtility.ToJson(data, true);    

        Debug.Log(data);
        
        StartCoroutine(PostDataCoroutine("http://www.localhost:5000/guest-book/store", json));
    }
     
    IEnumerator PostDataCoroutine(string url, string bodyJsonString) 
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