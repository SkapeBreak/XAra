using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections.Generic;
using SimpleJSON;

public class GetActivityList : MonoBehaviour
{
    [SerializeField] private GameObject activityCardTemplate;
 
    void Start()
    {
        StartCoroutine(GetActivityData());
    }
 
    IEnumerator GetActivityData()
    {
        string uri = "http://localhost:3000/activities/";

        using(UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError || webRequest.isHttpError)
            {
                Debug.Log(webRequest.error);
            }
            else
            {
                JSONNode activitiesParse = JSON.Parse(webRequest.downloadHandler.text);

                for (int i = 0; i < activitiesParse.Count; i++) 
                {
                    GameObject activityCard = Instantiate(activityCardTemplate) as GameObject;
             
                    activityCard.SetActive(true);
                    
                    activityCard.GetComponent<ActivityButton>().SetActivityName(activitiesParse[i]["name"]);
                    activityCard.GetComponent<ActivityButton>().SetActivityLocation(activitiesParse[i]["location"]);
                    activityCard.GetComponent<ActivityButton>().SetActivityStats(activitiesParse[i]["stats"]);
                    activityCard.GetComponent<ActivityButton>().SetActivityDifficulty(activitiesParse[i]["difficulty"]);

                    activityCard.transform.SetParent(activityCardTemplate.transform.parent, false);
                }
            }
        }
    }
}