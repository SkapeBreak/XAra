using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentManager : MonoBehaviour
{
    public static PersistentManager Instance { get ; private set; }

    public string currentSuite = "Suite888";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
