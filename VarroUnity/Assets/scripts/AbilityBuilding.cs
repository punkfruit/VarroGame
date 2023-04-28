using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBuilding : MonoBehaviour
{
    public GameObject roundThing;
    // Start is called before the first frame update
    void Start()
    {
        roundThing.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void hideRoundThing()
    {
        roundThing.SetActive(false);
    }

    public void showRoundThing()
    {
        roundThing.SetActive(!roundThing.activeInHierarchy);
    }
}
