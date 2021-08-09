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
    [SerializeField] GameObject amenityIconTemplate;
    [SerializeField] GameObject amenityContent;
    [SerializeField] GameObject closeX;

    GameObject amenityId;
    GameObject endpoint;
    JSONNode amenitiesParse;

    public static string amenityName;
    public static string amenityAddress;
    public static string amenityPhone;
    public static string amenityWebsite;
    public static string amenityHours;
    public static string amenityRating;
    
    public void AmenityOnClick()
    {
        StartCoroutine(GetAmenityData());
    }
 
    void OpenPopUp()
    {
        amenityId = EventSystem.current.currentSelectedGameObject;

        amenityName = amenitiesParse[amenityId.name]["name"];
        amenityAddress = amenitiesParse[amenityId.name]["address"];
        amenityPhone = amenitiesParse[amenityId.name]["phone"];
        amenityWebsite = amenitiesParse[amenityId.name]["website"];
        amenityHours = amenitiesParse[amenityId.name]["hours"];
        amenityRating = amenitiesParse[amenityId.name]["rating"];

        popUpAmenityDescription.SetActive(true);
    }

    public void ClosePopUp()
    {
        popUpAmenityDescription.SetActive(false);
    }

    IEnumerator GetAmenityData()
    {
        closeX.SetActive(true);
        amenityContent.SetActive(true);

        endpoint = EventSystem.current.currentSelectedGameObject;

        string uri = "http://localhost:4000/" + endpoint.name;

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
                    GameObject amenityCard = Instantiate(amenityCardTemplate) as GameObject;

                    amenityCard.SetActive(true);

                    amenityCard.GetComponent<Button>().onClick.AddListener(OpenPopUp);
                    amenityCard.name = i.ToString();

                    amenityCard.GetComponent<AmenityButton>().SetAmenityName(amenitiesParse[i]["name"]);
                    amenityCard.GetComponent<AmenityButton>().SetAmenityHours(amenitiesParse[i]["hours"]);
                    amenityCard.GetComponent<AmenityButton>().SetAmenityRating(amenitiesParse[i]["rating"]);

                    amenityCard.transform.SetParent(amenityCardTemplate.transform.parent, false);

                    amenityIconTemplate.GetComponent<RawImage>().texture = Resources.Load<Texture2D>("AmenityIcons/" + endpoint.name + "/" + i.ToString());
                }
                
                GameObject.Find("HostRecommendationCanvas").SetActive(false);
            }
        }
    } 
}