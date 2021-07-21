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
    [SerializeField] private GameObject activityOverviewTemplate;
    private string overviewDescription;
    InputField overview;

    void Update()
    {
        overview = GameObject.Find("Overview").GetComponent<InputField>();
        overview.text = GetActivityList.activityOverviewText;
    }
}
