using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivityButton : MonoBehaviour
{
    [SerializeField]
    private Text activityName;
    [SerializeField]
    private Text activityLocation;
    [SerializeField]
    private Text activityStats;
    [SerializeField]
    private Text activityDifficulty;


public void SetActivityName(string textString) 
{
    activityName.text = textString;
}

public void SetActivityLocation(string textString) 
{
    activityLocation.text = textString;
}

public void SetActivityStats(string textString) 
{
    activityStats.text = textString;
}

public void SetActivityDifficulty(string textString) 
{
    activityDifficulty.text = textString;
}

}
