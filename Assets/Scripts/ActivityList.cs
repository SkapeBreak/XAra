using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ActivityList : MonoBehaviour
{
    [SerializeField]
    private GameObject activityCardTemplate;

    string[] name = {
        "Name 1", 
        "Name 2",
        "Name 3",
        "Name 4",
        "Name 5",
    };

    string[] location = {
        "Location 1", 
        "Location 2",
        "Location 3",
        "Location 4",
        "Location 5",
    };


   

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i <= 4; i++) 
        {
            GameObject activityCard = Instantiate(activityCardTemplate) as GameObject;
            activityCard.SetActive(true);
            
            activityCard.GetComponent<ActivityButton>().SetActivityName(name[i]);
            activityCard.GetComponent<ActivityButton>().SetActivityLocation(location[i]);
            activityCard.GetComponent<ActivityButton>().SetActivityStats("Stats #" + i);
            activityCard.GetComponent<ActivityButton>().SetActivityDifficulty("Difficulty #" + i);

            activityCard.transform.SetParent(activityCardTemplate.transform.parent, false);
        }
    }


}
