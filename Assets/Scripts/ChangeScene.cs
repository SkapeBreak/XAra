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
    // public void ChangeToARView()
    // {
    //     SceneManager.LoadScene("ARView");
    // }
    // public void ChangeToDemo()
    // {
    //     SceneManager.LoadScene("Demo");
    // }
    public void ChangeToEAR()
    {
        SceneManager.LoadScene("eAR");
    }
    public void ChangeToHome()
    {
        SceneManager.LoadScene("HomePage");
    }
    public void ChangeToStickNotes()
    {
        SceneManager.LoadScene("StickyNotes");
    }
}