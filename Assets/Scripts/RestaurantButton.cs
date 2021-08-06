using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestaurantButton : MonoBehaviour
{
    [SerializeField] private Text restaurantName;
    [SerializeField] private Text restaurantSchedule;
    [SerializeField] private Text restaurantRating;

    public void SetRestaurantName(string textString) 
    {
        restaurantName.text = textString;
    }

    public void SetRestaurantSchedule(string textString) 
    {
        restaurantSchedule.text = textString;
    }

    public void SetRestaurantRating(string textString) 
    {
        restaurantRating.text = textString;
    }
}
