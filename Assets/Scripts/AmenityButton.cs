using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using System.Collections.Generic;
using System;

public class AmenityButton : MonoBehaviour
{
    [SerializeField] private Text amenityName;
    [SerializeField] private Text amenityHours;
    [SerializeField] private Text amenityRating;
    [SerializeField] private RawImage amenityIcon;

    public void SetAmenityName(string textString) 
    {
        amenityName.text = textString;
    }

    public void SetAmenityHours(string textString) 
    {
        amenityHours.text = textString;
    }

    public void SetAmenityRating(string textString) 
    {
        amenityRating.text = textString;
    }

    public void SetAmenityIcon(string textString) 
    {
        amenityIcon.texture = Resources.Load<Texture2D>("AmenityIcons/" + textString);
    }
}
