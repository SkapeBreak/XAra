using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{   
    public void ChangeToHostRecommendations()
    {
        SceneManager.LoadScene("HostRecommendations");
    }
    public void ChangeToGuestBook()
    {
        SceneManager.LoadScene("GuestBook");
    }
    public void ChangeToQRCode()
    {
        SceneManager.LoadScene("Demo");
    }
    public void ChangeToAR()
    {
        SceneManager.LoadScene("eAR");
    }
       public void ChangeToHome()
    {
        SceneManager.LoadScene("HomePage");
    }
    public void ChangeToSignInPage()
    {
        SceneManager.LoadScene("SignInPage");
    }
}