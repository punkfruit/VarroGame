using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWall : MonoBehaviour
{
    public int health = 100;
    //public UnitController unit;
    public List<UnitController> units = new List<UnitController>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamageEnemyWall(int dam)
    {
        health -= dam;

        if(health <= 0)
        {
            ResetUnit();
            DestroyWall();
        }
    }

    public void ResetUnit()
    {
        
        foreach (UnitController unit in units)
        {
            unit.EnWall = null;
            unit.moveTowardEnemyBase = true;
            unit.fireAtTarget = false;
            unit.targetPosition = null;
        }
    }

    public void DestroyWall()
    {
        Destroy(gameObject);
    }
}
