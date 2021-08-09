using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CloseWindow : MonoBehaviour
{
    [SerializeField] GameObject WindowToClose;
    [SerializeField] GameObject TransitionWindow;

    public void CloseOnClick()
    {
        if (EventSystem.current.currentSelectedGameObject.name == "CloseAmenityList")
        {
            Destroy(GameObject.Find("0"));
            Destroy(GameObject.Find("1"));
            Destroy(GameObject.Find("2"));
            Destroy(GameObject.Find("3"));
            Destroy(GameObject.Find("4"));

            WindowToClose.SetActive(false);
            TransitionWindow.SetActive(true);

            GameObject.Find("CloseAmenityList").SetActive(false);
        }
        else
        {
            WindowToClose.SetActive(false);
        }
    }
}
