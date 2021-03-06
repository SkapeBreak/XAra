using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using SimpleJSON;
using System;

public class GetManualList : MonoBehaviour
{
    [SerializeField] private GameObject manualTemplate;

    // public Text manualLabel;
    // public Image manualIcon;

    public static string manualID;

    JSONNode manualParse;

    void Start()
    {
        StartCoroutine(GetManualListData());
    }

    public void OnManualClick()
    {
        manualID = EventSystem.current.currentSelectedGameObject.name;
        // Debug.Log(manualID.name);
        SceneManager.LoadScene("bookcanvaspage");
        DontDestroyOnLoad(gameObject);
    }

    IEnumerator GetManualListData()
    {
        // endpoint = EventSystem.current.currentSelectedGameObject;

        string uri = "http://xaramyhost.tk:4000/manuals";

        using(UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError || webRequest.isHttpError)
            {
                Debug.Log(webRequest.error);
            }
            else
            {
                manualParse = JSON.Parse(webRequest.downloadHandler.text);

                for (int i = 0; i < manualParse.Count; i++) 
                {
                    // if (manualParse[i]["suiteId"] == PersistentManager.Instance.currentSuiteId)
                    // {
                        GameObject photoCard = Instantiate(manualTemplate) as GameObject;

                        photoCard.SetActive(true);
                        photoCard.name = manualParse[i]["deeplink"];

                        photoCard.GetComponent<ManualTemplateButton>().SetManualName(manualParse[i]["name"]);
                        photoCard.GetComponent<ManualTemplateButton>().SetManualIcon(i.ToString());

                        // manualIcon.sprite = Resources.Load<Sprite>("ManualIcons/" + i.ToString());

                        // manualLabel.text = manualParse[i]["name"];

                        photoCard.transform.SetParent(manualTemplate.transform.parent, false);
                        
                        
                    // }
                }
            }
        }
    }
}