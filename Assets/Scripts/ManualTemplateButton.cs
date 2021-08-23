using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using System.Collections.Generic;
using System;

public class ManualTemplateButton : MonoBehaviour
{
    [SerializeField] private Text manualName;
    [SerializeField] private Image manualIcon;

    public void SetManualName(string textString) 
    {
        manualName.text = textString;
    }

    public void SetManualIcon(string textString) 
    {
        manualIcon.sprite = Resources.Load<Sprite>("ManualIcons/" + textString);
    }

}
