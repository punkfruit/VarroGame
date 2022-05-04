using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerOne : MonoBehaviour
{
    public float timer;
    private float counter;

    public GameObject unitToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        counter = timer;
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
}
