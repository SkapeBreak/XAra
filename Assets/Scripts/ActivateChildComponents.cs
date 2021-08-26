using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateChildComponents : MonoBehaviour
{
    
    public GameObject adminCanvas;

    public void onButtonClick()
    {
        // DontDestroyOnLoad(gameObject);
        
        for(int i = 0; i < transform.childCount; ++i) 
        {
            // Debug.Log(transform.GetChild(i).gameObject);
            transform.GetChild(1).gameObject.SetActive(true);
        }
    }
}
