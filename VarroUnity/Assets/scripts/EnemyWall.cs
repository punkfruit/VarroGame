using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWall : MonoBehaviour
{
    public float rate = 20;//amount health goes up
    public float health = 800;
    float maxHealth;
    
    public int stage = 1; // stage is divided into 4, 1 means 100% 2 means 75, etc
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

        maxHealth = health;
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



        if(stage == 1)
        {
            if(health < maxHealth)
            {
                health += rate * Time.deltaTime;
            }
        }

        if(stage == 2)
        {
            if(health < (maxHealth / 100 * 75))
            {
                health += rate * Time.deltaTime;
            }
        }

        if (stage == 3)
        {
            if (health < (maxHealth / 100 * 50))
            {
                health += rate * Time.deltaTime;
            }
        }

        if (stage == 4)
        {
            if (health < (maxHealth / 100 * 25))
            {
                health += rate * Time.deltaTime;
            }
        }

    }

    public void DamageEnemyWall(int dam)
    {
        health -= dam;

        if(health < (maxHealth / 100 * 75))
        {
            stage = 2;
        }
        if (health < (maxHealth / 100 * 50))
        {
            stage = 3;
        }
        if (health < (maxHealth / 100 * 25))
        {
            stage = 4;
        }
        //switch stages


        if (health <= 0)
        {
            ResetUnit();
            //DestroyWall();
            explode = true;
            boxColid.enabled = false;
            //maybe hide health bar?
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
