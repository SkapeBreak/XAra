using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortraitPhoto : MonoBehaviour
{
    public GameObject guestBookPhoto; 
    public Sprite nextPhoto;
    public Sprite previousPhoto;

    public void GetNextPhotoOnClick() 
    {
        guestBookPhoto.GetComponent<SpriteRenderer>().sprite = nextPhoto;
    }

    public void GetPreviousPhotoOnClick() 
    {
        guestBookPhoto.GetComponent<SpriteRenderer>().sprite = previousPhoto;
    }
}