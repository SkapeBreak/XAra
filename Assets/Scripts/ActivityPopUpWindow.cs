using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ActivityPopUpWindow : MonoBehaviour
{

    [SerializeField] GameObject popup;


    public void Open()
    {        
        popup.SetActive(true);    
    }

    public void Close()
    {
        popup.SetActive(false);
    }

}
