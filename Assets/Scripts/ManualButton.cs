using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManualButton : MonoBehaviour
{
    [SerializeField] private Text manualNameHolder;
    [SerializeField] private Text manualBodyHolder;

    public void SetManualName(string textString)
    {
        manualNameHolder.text = textString;
    }
    
    public void SetManualBody(string textString)
    {
        manualBodyHolder.text = textString;
    }
}
