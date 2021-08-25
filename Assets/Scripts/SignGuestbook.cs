using UnityEngine;
using System.Text;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.UI;
using SimpleJSON;
using System;
using SimpleFileBrowser;
 
public class SignGuestbook : MonoBehaviour {
    
    public InputField commentInput;
    public GameObject guestbookCanvas;
    public GameObject signGuestbook;
    public GameObject fileBrowser;
    public GameObject addedPhoto;

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
        addedPhoto.SetActive(true);
        
        UserData data = new UserData();
        data.comment = commentInput.text;
        data.suiteId = "suite888"; //PersistentManager.Instance.currentSuiteId;
        data.avatar = SimpleFileBrowser.FileBrowser.Result[0];

        Debug.Log("comment " + data.comment);
        Debug.Log("suiteId " + data.suiteId);
        Debug.Log("avatar " + data.avatar);

        string json = JsonUtility.ToJson(data, true);  

        Debug.Log("json " + json);  
        
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