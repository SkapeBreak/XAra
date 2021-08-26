using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{  
    public void ChangeToHostRecommendations()
    {
        // string suiteId = PersistentManager.Instance.currentSuiteId;
        // if (suiteId != "NotFound")
        {
            SceneManager.LoadScene("HostRecommendations");
        }
    }
    public void ChangeToGuestBook()
    {
        // string suiteId = PersistentManager.Instance.currentSuiteId;
        // if (suiteId != "NotFound")
        {
        SceneManager.LoadScene("GuestBook");
        }
    }
    public void ChangeToQRCode()
    {
        // string suiteId = PersistentManager.Instance.currentSuiteId;
        // if (suiteId != "NotFound")
        {
        SceneManager.LoadScene("QRCodePage");
        }
    }
    public void ChangeToAR()
    {
        // string suiteId = PersistentManager.Instance.currentSuiteId;
        // if (suiteId != "NotFound")
        {
        SceneManager.LoadScene("eAR");
        }
    }
    public void ChangeToHome()
    {
        // string suiteId = PersistentManager.Instance.currentSuiteId;
        // if (suiteId != "NotFound")
        {
        SceneManager.LoadScene("HomePage");
        }
    }
    public void ChangeToSignInPage()
    {
        // string suiteId = PersistentManager.Instance.currentSuiteId;
        // if (suiteId != "NotFound")
        {
        SceneManager.LoadScene("SignInPage");
        }
    }

    public void ChangeToStickynotes()
    {
        // string suiteId = PersistentManager.Instance.currentSuiteId;
        // if (suiteId != "NotFound")
        {
        SceneManager.LoadScene("StickyNotesPage");
        }
    }
    
    public void ChangeToNav()
    {
        // string suiteId = PersistentManager.Instance.currentSuiteId;
        // if (suiteId != "NotFound")
        {
        SceneManager.LoadScene("NavigationPage");
        }
    }
    
    public void ChangeToManual()
    {
        // string suiteId = PersistentManager.Instance.currentSuiteId;
        // if (suiteId != "NotFound")
        {
        SceneManager.LoadScene("ManualPage");
        }
    }

    public void SignIn()
    {
        SceneManager.LoadScene("QRCodePage");
    }

    public void ChangeToAdminPanel()
    {
        // string suiteId = PersistentManager.Instance.currentSuiteId;
        // if (suiteId != "NotFound")
        {
        SceneManager.LoadScene("AdminPanel");
        }
    }

    public void ChangeToAdmintickyNotesPage()
    {
        // string suiteId = PersistentManager.Instance.currentSuiteId;
        // if (suiteId != "NotFound")
        {      
        SceneManager.LoadScene("AdminStickyNotesPage");
        }
    }
    public void ChangeToAdminNavigationPage()
    {
        // string suiteId = PersistentManager.Instance.currentSuiteId;
        // if (suiteId != "NotFound")
        {
        SceneManager.LoadScene("AdminNavigationPage");
        }
    }
    public void ChangeToAdminQRCodePage()
    {
        // string suiteId = PersistentManager.Instance.currentSuiteId;
        // if (suiteId != "NotFound")
        {
        SceneManager.LoadScene("AdminQRCodePage");
        }
    }
}