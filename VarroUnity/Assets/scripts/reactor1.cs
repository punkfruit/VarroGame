using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reactor1 : MonoBehaviour
{
    public DefenderSpawner defSpawn;

    public int energyAmountToGive;

    public float timer;
    private float counter;


    // Start is called before the first frame update
    void Start()
    {
        counter = timer;
        defSpawn = FindObjectOfType<DefenderSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (counter > 0)
        {
            counter -= Time.deltaTime;
        }
        if (counter <= 0)
        {
            //SpawnUnit();
            GiveEnergy();
            counter = timer;
        }
    }

    public void GiveEnergy()
    {
        defSpawn.AddEnergy(energyAmountToGive);
    }
}
