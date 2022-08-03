using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerOne : MonoBehaviour
{
    public float timer;
    private float counter;

    public GameObject unitToSpawn;
    public GameObject roundThing;
    // Start is called before the first frame update
    void Start()
    {
        counter = timer;

        roundThing.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if(counter > 0)
        {
            counter -= Time.deltaTime;
        }
        if(counter <= 0)
        {
            SpawnUnit();
            counter = timer;
        }
    }


    public void SpawnUnit()
    {
        Instantiate(unitToSpawn, transform.position, transform.rotation);
    }


    private void OnMouseDown()
    {
        /*
        Debug.Log("mouse down!!");

        if (roundThing.activeInHierarchy)
        {
            roundThing.SetActive(false);
        }
        else
        {
            roundThing.SetActive(true);
        }
        */

        roundThing.SetActive(true);
    }

    public void hideRoundThing()
    {
        roundThing.SetActive(false);
    }
}
