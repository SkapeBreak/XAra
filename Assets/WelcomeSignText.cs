using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class WelcomeSignText : MonoBehaviour
{
	TMP_Text ui_Text;
	CreateMapSample1 mapManager;

    void Start()
    {
		ui_Text = GetComponent<TMP_Text>();
		mapManager = FindObjectOfType<CreateMapSample1>();
		ui_Text.text = mapManager.ReturnMapName();
    }






    
}
