using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivityPopUpWindow : MonoBehaviour
{

    [SerializeField] GameObject popup;

    // Start is called before the first frame update
    private void Start()
    {
        transform.localScale = Vector2.zero;
    }

    public void Open()
    {
        transform.LeanScale(Vector2.one, 0.5f);
        popup.SetActive(true);
        
    }

    public void Close()
    {
        transform.LeanScale(Vector2.zero, 1f);
        popup.SetActive(false);
        
    }

}
