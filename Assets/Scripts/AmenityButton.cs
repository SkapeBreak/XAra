using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmenityButton : MonoBehaviour
{
    [SerializeField] private Text amenityName;
    [SerializeField] private Text amenityHours;
    [SerializeField] private Text amenityRating;

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
}
