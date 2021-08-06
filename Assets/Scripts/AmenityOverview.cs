using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using System.Collections.Generic;
using SimpleJSON;
using System;
using static GetAmenityList;

public class AmenityOverview : MonoBehaviour
{
    InputField address;
    InputField name;
    InputField phone;
    InputField website;
    InputField hours;
    InputField rating;

    void Update()
    {
        address = GameObject.Find("Address").GetComponent<InputField>();
        address.text = GetAmenityList.amenityAddress;

        name = GameObject.Find("Name").GetComponent<InputField>();
        name.text = GetAmenityList.amenityName;

        phone = GameObject.Find("Phone").GetComponent<InputField>();
        phone.text = GetAmenityList.amenityPhone;

        website = GameObject.Find("Website").GetComponent<InputField>();
        website.text = GetAmenityList.amenityWebsite;

        hours = GameObject.Find("Hours").GetComponent<InputField>();
        hours.text = GetAmenityList.amenityHours;

        rating = GameObject.Find("Rating").GetComponent<InputField>();
        rating.text = GetAmenityList.amenityRating;      
    }
}
