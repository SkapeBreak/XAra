using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using System.Collections.Generic;
using SimpleJSON;
using System;

public class GetAmenityList : MonoBehaviour
{
    [SerializeField] private GameObject amenityCardTemplate;
    [SerializeField] GameObject popUpAmenityDescription;
    [SerializeField] GameObject amenityContent;

    GameObject amenityId;
    GameObject endpoint;

    JSONNode amenitiesParse;
    JSONNode restaurantsParse;

    public static string amenityName;
    public static string amenityAddress;
    public static string amenityPhone;
    public static string amenityWebsite;
    public static string amenityHours;
    public static string amenityRating;
    public static string amenityComment;

    private void Start()
    {
        StartCoroutine(GetRestaurantData());
    }
    
    public void AmenityOnClick()
    {
        StartCoroutine(GetAmenityData());
    }
 
    void OpenPopUp()
    {
        if (endpoint == null)
        {
            amenityId = EventSystem.current.currentSelectedGameObject;

            amenityName = restaurantsParse[amenityId.name]["name"];
            amenityAddress = restaurantsParse[amenityId.name]["address"];
            amenityPhone = restaurantsParse[amenityId.name]["phone"];
            amenityWebsite = restaurantsParse[amenityId.name]["website"];
            amenityHours = restaurantsParse[amenityId.name]["hours"];
            amenityRating = restaurantsParse[amenityId.name]["rating"];
            amenityComment = restaurantsParse[amenityId.name]["comment"];
        }
        else{
            amenityId = EventSystem.current.currentSelectedGameObject;

            amenityName = amenitiesParse[amenityId.name]["name"];
            amenityAddress = amenitiesParse[amenityId.name]["address"];
            amenityPhone = amenitiesParse[amenityId.name]["phone"];
            amenityWebsite = amenitiesParse[amenityId.name]["website"];
            amenityHours = amenitiesParse[amenityId.name]["hours"];
            amenityRating = amenitiesParse[amenityId.name]["rating"];
            amenityComment = amenitiesParse[amenityId.name]["comment"];
        }

        popUpAmenityDescription.SetActive(true);
    }

    public void ClosePopUp()
    {
        popUpAmenityDescription.SetActive(false);
    }

    IEnumerator GetAmenityData()
    {
        amenityContent.SetActive(true);

        endpoint = EventSystem.current.currentSelectedGameObject;

        string uri = "http://localhost:5000/" + endpoint.name;

        using(UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError || webRequest.isHttpError)
            {
                Debug.Log(webRequest.error);
            }
            else
            {
                amenitiesParse = JSON.Parse(webRequest.downloadHandler.text);

                for (int i = 0; i < amenitiesParse.Count; i++) 
                {
                    if (amenitiesParse[i]["suiteId"] == PersistentManager.Instance.currentSuiteId)
                    {
                        Destroy(GameObject.Find(i.ToString()));

                        GameObject amenityCard = Instantiate(amenityCardTemplate) as GameObject;

                        amenityCard.SetActive(true);

                        amenityCard.GetComponent<Button>().onClick.AddListener(OpenPopUp);
                        
                        amenityCard.name = i.ToString();
    
                        amenityCard.GetComponent<AmenityButton>().SetAmenityName(amenitiesParse[i]["name"]);
                        amenityCard.GetComponent<AmenityButton>().SetAmenityHours(amenitiesParse[i]["hours"]);
                        amenityCard.GetComponent<AmenityButton>().SetAmenityRating(amenitiesParse[i]["rating"]);
                        amenityCard.GetComponent<AmenityButton>().SetAmenityIcon(endpoint.name + "/" + i.ToString());

                        amenityCard.transform.SetParent(amenityCardTemplate.transform.parent, false);
                    }
                }
            }
        }
    } 

    IEnumerator GetRestaurantData()
    {
        string uri = "http://localhost:5000/restaurants";

        using(UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError || webRequest.isHttpError)
            {
                Debug.Log(webRequest.error);
            }
            else
            {
                restaurantsParse = JSON.Parse(webRequest.downloadHandler.text);

                for (int i = 0; i < restaurantsParse.Count; i++) 
                {
                    if (restaurantsParse[i]["suiteId"] == PersistentManager.Instance.currentSuiteId)
                    {
                        GameObject amenityCard = Instantiate(amenityCardTemplate) as GameObject;

                        amenityCard.SetActive(true);

                        amenityCard.GetComponent<Button>().onClick.AddListener(OpenPopUp);
                        
                        amenityCard.name = i.ToString();
    
                        amenityCard.GetComponent<AmenityButton>().SetAmenityName(restaurantsParse[i]["name"]);
                        amenityCard.GetComponent<AmenityButton>().SetAmenityHours(restaurantsParse[i]["hours"]);
                        amenityCard.GetComponent<AmenityButton>().SetAmenityRating(restaurantsParse[i]["rating"]);
                        amenityCard.GetComponent<AmenityButton>().SetAmenityIcon("restaurants/" + i.ToString());

                        amenityCard.transform.SetParent(amenityCardTemplate.transform.parent, false);
                    }
                }
            }
        }
    } 
}