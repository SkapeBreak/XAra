using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using SimpleJSON;
using System;
using UnityEngine.EventSystems;
using UnityEngine.Networking;

public class SignInToCurrentSuite : MonoBehaviour
{
    public static SignInToCurrentSuite Instance { get; private set; }
    public string deeplinkURL;
    bool validSuiteId;
    string suiteId;

    public GameObject warningPopUp;
    JSONNode suitesParse;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;                
            Application.deepLinkActivated += onDeepLinkActivated;

            if (!string.IsNullOrEmpty("unitydl://mylink?suite888"))//"unitydl://mylink?88
            {
                onDeepLinkActivated("unitydl://mylink?suite888");//Application.absoluteURL
            }
            else deeplinkURL = "[none]";

            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(warningPopUp);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StartCoroutine(authSuite());
    }

    private void onDeepLinkActivated(string url)
    {
        deeplinkURL = url;
        suiteId = deeplinkURL.Split("?"[0])[1];
        Debug.Log(suiteId);

        SceneManager.LoadScene("HomePage");
    }

    IEnumerator authSuite()
    {
        string uri = "http://localhost:4000/suites";

        using(UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError || webRequest.isHttpError)
            {
                Debug.Log(webRequest.error);
            }
            else
            {
                suitesParse = JSON.Parse(webRequest.downloadHandler.text);
                Debug.Log(suiteId);

                for (int i = 0; i < suitesParse.Count; i++) 
                {
                    if (suitesParse[i]["suiteId"] == suiteId)
                    {
                        Debug.Log("Auth Succeeded");

                        validSuiteId = true;
                        break;
                    }
                    else
                    {
                        Debug.Log("Suite Not Found");

                        PersistentManager.Instance.currentSuiteId = "NotFound";
                        warningPopUp.SetActive(true);
                        validSuiteId = false;
                    }
                }
                 if (validSuiteId) 
                {
                    PersistentManager.Instance.currentSuiteId = suiteId;
                }
            }
        }
    }
}

