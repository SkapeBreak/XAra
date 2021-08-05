using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using System.Collections.Generic;
using SimpleJSON;
using System;

public class GetRestaurantList : MonoBehaviour
{
    [SerializeField] private GameObject restaurantCardTemplate;
    [SerializeField] GameObject popUpRestaurantDescription;
    [SerializeField] GameObject restaurantIconTemplate;

    GameObject restaurantId;
    JSONNode restaurantsParse;

    public static string restaurantName;
    public static string restaurantAddress;
    public static string restaurantPhone;
    public static string restaurantMenu;
    public static string restaurantSchedule;
    public static string restaurantRating;
    
    void Start()
    {
        StartCoroutine(GetRestaurantData());
    }
 
    void OpenPopUp()
    {
        restaurantId = EventSystem.current.currentSelectedGameObject;

        restaurantName = restaurantsParse[restaurantId.name]["name"];
        restaurantAddress = restaurantsParse[restaurantId.name]["address"];
        restaurantPhone = restaurantsParse[restaurantId.name]["phone"];
        restaurantMenu = restaurantsParse[restaurantId.name]["menu"];
        restaurantSchedule = restaurantsParse[restaurantId.name]["schedule"];
        restaurantRating = restaurantsParse[restaurantId.name]["rating"];

        popUpRestaurantDescription.SetActive(true);
    }

    public void ClosePopUp()
    {
        popUpRestaurantDescription.SetActive(false);
    }

    IEnumerator GetRestaurantData()
    {

        string uri = "http://localhost:3000/restaurants";

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
                    GameObject restaurantCard = Instantiate(restaurantCardTemplate) as GameObject;

                    restaurantCard.SetActive(true);

                    restaurantCard.GetComponent<Button>().onClick.AddListener(OpenPopUp);
                    restaurantCard.name = i.ToString();

                    restaurantCard.GetComponent<RestaurantButton>().SetRestaurantName(restaurantsParse[i]["name"]);
                    // restaurantCard.GetComponent<RestaurantButton>().SetRestaurantAddress(restaurantsParse[i]["address"]);
                    // restaurantCard.GetComponent<RestaurantButton>().SetRestaurantPhone(restaurantsParse[i]["phone"]);
                    restaurantCard.GetComponent<RestaurantButton>().SetRestaurantSchedule(restaurantsParse[i]["schedule"]);
                    // restaurantCard.GetComponent<RestaurantButton>().SetRestaurantMenu(restaurantsParse[i]["menu"]);
                    restaurantCard.GetComponent<RestaurantButton>().SetRestaurantRating(restaurantsParse[i]["rating"]);

                    restaurantCard.transform.SetParent(restaurantCardTemplate.transform.parent, false);

                    restaurantIconTemplate.GetComponent<RawImage>().texture = Resources.Load<Texture2D>("RestaurantIcons/" + i.ToString() + "/" + i.ToString());
                }
            }
        }
    } 
}