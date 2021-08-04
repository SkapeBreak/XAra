using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OpenLink : MonoBehaviour
{
    GameObject selectedGameObject;
    string googleMapsURL;
    
    public void OpenLinkOnClick() 
    {
        selectedGameObject = EventSystem.current.currentSelectedGameObject;
        Debug.Log(selectedGameObject.name);

        if (selectedGameObject.name == "RestaurantAddress" || selectedGameObject.name == "AddressText") 
        {
            googleMapsURL = "http://maps.google.co.in/maps?q=";
        } 
        else if (selectedGameObject.name == "RestaurantMenu" || selectedGameObject.name == "MenuText")
        {
            googleMapsURL = "";
        }
        Application.OpenURL(googleMapsURL + selectedGameObject.GetComponent<Text>().text);
    }
}
