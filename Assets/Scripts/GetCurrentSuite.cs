using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCurrentSuite : MonoBehaviour
{
    void Start()
    {
        Debug.Log(PersistentManager.Instance.currentSuite);
    }
}