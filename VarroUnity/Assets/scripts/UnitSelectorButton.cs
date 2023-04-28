using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelectorButton : MonoBehaviour
{
    public GameObject[] units;
    public SpawnerOne spawner;
    public AbilityBuilding abBuild;
    //public GameObject highlight;

   


    public void ButtonParty(int selector) //the code that sends which unit is to be spawned
    {
        spawner.unitToSpawn = units[selector];

        spawner.hideRoundThing();
    }

    public void AbilityParty(int selector)
    {

        abBuild.hideRoundThing();
    }

    
}
