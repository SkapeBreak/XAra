using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using System.Collections.Generic;
using SimpleJSON;
using System;
using static GetRestaurantList;

public class RestaurantOverview : MonoBehaviour
{
    InputField address;
    InputField name;
    InputField phone;
    InputField menu;
    InputField schedule;
    InputField rating;

    void Update()
    {
        address = GameObject.Find("Address").GetComponent<InputField>();
        address.text = GetRestaurantList.restaurantAddress;

        name = GameObject.Find("Name").GetComponent<InputField>();
        name.text = GetRestaurantList.restaurantName;

        phone = GameObject.Find("Phone").GetComponent<InputField>();
        phone.text = GetRestaurantList.restaurantPhone;

        menu = GameObject.Find("Menu").GetComponent<InputField>();
        menu.text = GetRestaurantList.restaurantMenu;

        schedule = GameObject.Find("Schedule").GetComponent<InputField>();
        schedule.text = GetRestaurantList.restaurantSchedule;

        rating = GameObject.Find("Rating").GetComponent<InputField>();
        rating.text = GetRestaurantList.restaurantRating;      
    }
}
