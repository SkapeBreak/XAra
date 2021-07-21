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
    // [SerializeField] private GameObject activityOverviewTemplate;
    // private string overviewDescription;
    InputField overview;
    InputField name;
    // InputField distance;
    // InputField elevation;
    // InputField difficulty;

    void Update()
    {
        overview = GameObject.Find("Overview").GetComponent<InputField>();
        overview.text = GetActivityList.activityOverviewText;

        name = GameObject.Find("ActivityName").GetComponent<InputField>();
        name.text = GetActivityList.activityName;

        // distance = GameObject.Find("Distance").GetComponent<InputField>();
        // distance.text = GetActivityList.activityOverviewText;

        // elevation = GameObject.Find("Elevation").GetComponent<InputField>();
        // elevation.text = GetActivityList.activityOverviewText;

        // difficulty = GameObject.Find("Difficulty").GetComponent<InputField>();
        // difficulty.text = GetActivityList.activityOverviewText;
    }
}
