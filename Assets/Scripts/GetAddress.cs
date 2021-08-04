using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GetAddress : MonoBehaviour
{
    GameObject urlLink;

    public void GetAddressOnClick() 
    {
        urlLink = EventSystem.current.currentSelectedGameObject;
        Debug.Log(urlLink);
    }
}
