using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{   
    public void ChangeToHome()
    {
        SceneManager.LoadScene("LandingPage");
    }
        public void ChangeToPath()
    {
        SceneManager.LoadScene("MapPage");
    }
        public void ChangeToARView()
    {
        SceneManager.LoadScene("ARView");
    }
        public void ChangeToDemo()
    {
        SceneManager.LoadScene("Demo");
    }
    public void ChangeToEAR()
    {
        SceneManager.LoadScene("eAR");
    }
}