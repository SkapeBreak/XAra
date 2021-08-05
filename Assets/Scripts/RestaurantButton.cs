using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestaurantButton : MonoBehaviour
{
    [SerializeField] private Text restaurantName;
    // [SerializeField] private Text restaurantAddress;
    // [SerializeField] private Text restaurantPhone;
    [SerializeField] private Text restaurantSchedule;
    // [SerializeField] private Text restaurantMenu;
    [SerializeField] private Text restaurantRating;

    public void SetRestaurantName(string textString) 
    {
        restaurantName.text = textString;
    }

    // public void SetRestaurantAddress(string textString) 
    // {
    //     restaurantAddress.text = textString;
    // }

    // public void SetRestaurantPhone(string textString) 
    // {
    //     restaurantPhone.text = textString;
    // }

    public void SetRestaurantSchedule(string textString) 
    {
        restaurantSchedule.text = textString;
    }

    // public void SetRestaurantMenu(string textString) 
    // {
    //     restaurantMenu.text = textString;
    // }

    public void SetRestaurantRating(string textString) 
    {
        restaurantRating.text = textString;
    }
}
