using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWall : MonoBehaviour
{
    public int health = 100;
    //public UnitController unit;
    public List<UnitController> units = new List<UnitController>();

    public Transform[] explosionSpots;
    public float timeBetweenExplosions;
    private float counter;
    public bool explode = false;
    public GameObject explosion;
    public BoxCollider2D boxColid;

    // Start is called before the first frame update
    void Start()
    {
        counter = timeBetweenExplosions;
    }

    // Update is called once per frame
    void Update()
    {
        if (explode)
        {

            if(counter > 0)
            {
                counter -= Time.deltaTime;
            }

            if(counter <= 0)
            {
                Instantiate(explosion, explosionSpots[Random.Range(0, explosionSpots.Length)]);
                counter = timeBetweenExplosions;
            }


        }
    }

    public void DamageEnemyWall(int dam)
    {
        health -= dam;

        if(health <= 0)
        {
            ResetUnit();
            //DestroyWall();
            explode = true;
            boxColid.enabled = false;
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
