using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using System.Collections.Generic;
using SimpleJSON;
using System;
using static GetActivityList;

public class ActivityOverview : MonoBehaviour
{
    InputField description;
    InputField name;
    InputField distance;
    InputField elevation;
    InputField difficulty;
    InputField rating;

    void Update()
    {
        description = GameObject.Find("Overview").GetComponent<InputField>();
        description.text = GetActivityList.activityDescription;

        name = GameObject.Find("ActivityName").GetComponent<InputField>();
        name.text = GetActivityList.activityName;

        distance = GameObject.Find("Distance").GetComponent<InputField>();
        distance.text = GetActivityList.activityDistance;

        elevation = GameObject.Find("Elevation").GetComponent<InputField>();
        elevation.text = GetActivityList.activityElevation;

        difficulty = GameObject.Find("ActivityDifficulty").GetComponent<InputField>();
        difficulty.text = GetActivityList.activityDifficulty;

        rating = GameObject.Find("Rating").GetComponent<InputField>();
        rating.text = GetActivityList.activityRating;      
    }
}
