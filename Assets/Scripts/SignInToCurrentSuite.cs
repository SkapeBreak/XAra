using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignInToCurrentSuite : MonoBehaviour
{
    public Text currentSuiteText;

    public void SignInOnClick() 
    {
        currentSuiteText.text = PersistentManager.Instance.currentSuite;
    }
}
