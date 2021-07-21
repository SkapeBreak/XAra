using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using System.Collections.Generic;
using SimpleJSON;
using System;

public class GetActivityList : MonoBehaviour
{
    [SerializeField] private GameObject activityCardTemplate;
    [SerializeField] GameObject activityDescription;
    GameObject activityId;
    JSONNode activitiesParse;
    public static string activityOverviewText;
    
    void Start()
    {
        StartCoroutine(GetActivityData());
    }
 
    void OpenPopUp()
    {
        activityId = EventSystem.current.currentSelectedGameObject;
        activityOverviewText = activitiesParse[activityId.name]["description"];
        activityDescription.SetActive(true);
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
                activitiesParse = JSON.Parse(webRequest.downloadHandler.text);

                for (int i = 0; i < activitiesParse.Count; i++) 
                {
                    GameObject activityCard = Instantiate(activityCardTemplate) as GameObject;
             
                    activityCard.SetActive(true);
                    activityCard.GetComponent<Button>().onClick.AddListener(OpenPopUp);
                    activityCard.name = i.ToString();
                    
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