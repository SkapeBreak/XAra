using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ActivityList : MonoBehaviour
{
    Dictionary<string, string>[] activities = {
        new Dictionary<string, string>(), 
        new Dictionary<string, string>(),
        new Dictionary<string, string>(),
        new Dictionary<string, string>(),
        new Dictionary<string, string>(),
    };

    [SerializeField]
    private GameObject activityCardTemplate;

    // Start is called before the first frame update
    void Start()
    {
        activities[0].Add("name","South Glenmore Park Loop");
        activities[0].Add("location", "South Glenmore Park");
        activities[0].Add("stats","5.5 km, 1 h 22 m");
        activities[0].Add("difficulty","Easy");

        activities[1].Add("name","Glenmore Reservoir Trail");
        activities[1].Add("location", "South Glenmore Park");
        activities[1].Add("stats","15.3 km, 3 h 50 m");
        activities[1].Add("difficulty","Easy");

        activities[2].Add("name","Douglas Fir Trail");
        activities[2].Add("location", "Edworthy Park");
        activities[2].Add("stats","5.8 km, 1h 55 m");
        activities[2].Add("difficulty","Moderate");

        activities[3].Add("name","Weaselhead Flats");
        activities[3].Add("location", "Weaselhead Flats");
        activities[3].Add("stats","4.8 km, 1 h 12 m");
        activities[3].Add("difficulty","Easy");

        activities[4].Add("name","Fish Creek Votier Flats Trail");
        activities[4].Add("location", "Fish Creek Provincial Park");
        activities[4].Add("stats","9.0 km, 2 h 41 m");
        activities[4].Add("difficulty","Moderate");

        for (int i = 0; i <= 4; i++) 
        {
            GameObject activityCard = Instantiate(activityCardTemplate) as GameObject;
            activityCard.SetActive(true);
            
            activityCard.GetComponent<ActivityButton>().SetActivityName(activities[i]["name"]);
            activityCard.GetComponent<ActivityButton>().SetActivityLocation(activities[i]["location"]);
            activityCard.GetComponent<ActivityButton>().SetActivityStats(activities[i]["stats"]);
            activityCard.GetComponent<ActivityButton>().SetActivityDifficulty(activities[i]["difficulty"]);

            activityCard.transform.SetParent(activityCardTemplate.transform.parent, false);
        }
    }


}
