// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class SignInToCurrentSuite : MonoBehaviour
// {
//     public Text currentSuiteText;

//     public void SignInOnClick() 
//     {
//         currentSuiteText.text = PersistentManager.Instance.currentSuite;
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SignInToCurrentSuite : MonoBehaviour
{
    public static SignInToCurrentSuite Instance { get; private set; }
    public string deeplinkURL;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;                
            Application.deepLinkActivated += onDeepLinkActivated;
            if (!string.IsNullOrEmpty(Application.absoluteURL))
            {
                // Cold start and Application.absoluteURL not null so process Deep Link.
                onDeepLinkActivated(Application.absoluteURL);
            }
            // Initialize DeepLink Manager global variable.
            else deeplinkURL = "[none]";
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void onDeepLinkActivated(string url)
    {
        // Update DeepLink Manager global variable, so URL can be accessed from anywhere.
        deeplinkURL = url;
        
        // Decode the URL to determine action. 
        // In this example, the app expects a link formatted like this:
        // unitydl://mylink?scene1

        string suiteId = url.Split("?"[0])[1];
        bool validSuiteId;
        switch (suiteId)
        {
            case "suite888":
                PersistentManager.Instance.currentSuite = suiteId;
                validSuiteId = true;
                break;
            case "suite889":
                PersistentManager.Instance.currentSuite = suiteId;
                validSuiteId = true;
                break;
            default:
                validSuiteId = false;
                break;
        }
        if (validSuiteId) 
        {
            SceneManager.LoadScene("HomePage");
        }
    }
}

