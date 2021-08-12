using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScaleTween : MonoBehaviour
{
    [SerializeField] GameObject BookCanvas;



    public void BookOpen()
    {
        BookCanvas.SetActive(true);
        LeanTween.scale(BookCanvas, new Vector3(2,2,0), 0.5f);
    }

    public void BookClose()
    {
        LeanTween.scale(BookCanvas, new Vector3(0, 0, 0), 0.5f);
        BookCanvas.SetActive(false);
        
    }

}
