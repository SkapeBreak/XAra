using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
