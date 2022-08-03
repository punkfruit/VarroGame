using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelectorButton : MonoBehaviour
{
    public GameObject[] units;
    public SpawnerOne spawner;
    //public GameObject highlight;

    Ray ray;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        //highlight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ButtonParty(int selector)
    {
        spawner.unitToSpawn = units[selector];

        spawner.hideRoundThing();
    }

    
}
