using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelectorButton : MonoBehaviour
{
    public GameObject unit;
    public GameObject highlight;
    // Start is called before the first frame update
    void Start()
    {
        highlight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        highlight.SetActive(true);
    }

    private void OnMouseExit()
    {
        highlight.SetActive(false);
    }
}
