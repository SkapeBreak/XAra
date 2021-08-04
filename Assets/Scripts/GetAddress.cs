using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GetAddress : MonoBehaviour
{
    GameObject restaurantAddress;

    public void GetAddressOnClick() 
    {
        restaurantAddress = EventSystem.current.currentSelectedGameObject;
        Application.OpenURL("http://maps.google.co.in/maps?q=" + restaurantAddress.GetComponent<Text>().text);
    }
}
