using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivityList : MonoBehaviour
{
    [SerializeField]
    private GameObject activityCardTemplate;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i <= 5; i++) 
        {
            GameObject activityCard = Instantiate(activityCardTemplate) as GameObject;
            activityCard.SetActive(true);

            activityCard.GetComponent<ActivityButton>().SetActivityName("Activity #" + i);
            activityCard.GetComponent<ActivityButton>().SetActivityLocation("Location #" + i);
            activityCard.GetComponent<ActivityButton>().SetActivityStats("Stats #" + i);
            activityCard.GetComponent<ActivityButton>().SetActivityDifficulty("Difficulty #" + i);

            activityCard.transform.SetParent(activityCardTemplate.transform.parent, false);
        }
    }
}
