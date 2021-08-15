using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{   
    public void ChangeToHostRecommendations()
    {
        string suiteId = PersistentManager.Instance.currentSuiteId;
        if (suiteId != "NotFound")
        {
            Debug.Log(suiteId);
            SceneManager.LoadScene("HostRecommendations");
        }
    }
    public void ChangeToGuestBook()
    {
        string suiteId = PersistentManager.Instance.currentSuiteId;
        if (suiteId != "NotFound")
        {
        SceneManager.LoadScene("GuestBook");
        }
    }
    public void ChangeToQRCode()
    {
        string suiteId = PersistentManager.Instance.currentSuiteId;
        if (suiteId != "NotFound")
        {
        SceneManager.LoadScene("Demo");
        }
    }
    public void ChangeToAR()
    {
        string suiteId = PersistentManager.Instance.currentSuiteId;
        if (suiteId != "NotFound")
        {
        SceneManager.LoadScene("eAR");
        }
    }
    public void ChangeToHome()
    {
        string suiteId = PersistentManager.Instance.currentSuiteId;
        if (suiteId != "NotFound")
        {
        SceneManager.LoadScene("HomePage");
        }
    }
    public void ChangeToSignInPage()
    {
        string suiteId = PersistentManager.Instance.currentSuiteId;
        if (suiteId != null)
        {
        SceneManager.LoadScene("SignInPage");
        }
    }
}