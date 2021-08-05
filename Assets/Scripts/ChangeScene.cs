using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{   
    public void ChangeToLocalAttractions()
    {
        SceneManager.LoadScene("LocalAttractionsPage");
    }
        public void ChangeToPath()
    {
        SceneManager.LoadScene("MapPage");
    }
        public void ChangeToARView()
    {
        SceneManager.LoadScene("ARView");
    }
       public void ChangeToHome()
    {
        SceneManager.LoadScene("HomePage");
    }
}