using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    private Vector3 moveDirection;
    public Rigidbody2D theRB;
    public float speed = 5;
    public int lane;
    public LaneMarkers lm;

    public int health = 100;
    public bool moveTowardEnemyBase = true;


    public GameObject turret;
    public Transform targetPosition; //where the turret should face
    public EnemyWall EnWall; // only public so i can see in inspector

    public float RotationSpeed;
    private Quaternion _lookRotation;
    private Vector3 _direction;
    public bool turretLookAtTarget;

    public SpriteRenderer laserSR;
    //public GameObject laserGO;
    public bool fireAtTarget;
    public float laserShotLength;
    private float laserShotCounter;
    public float inBetweenShotLength;
    private float inBetweenShotCounter;
    public int laserDamage = 10;


    private float randoFactor;

    void Start()
    {
        lm = FindObjectOfType<LaneMarkers>();
        lane = Random.Range(0, lm.lanes.Length);

        inBetweenShotCounter = inBetweenShotLength;

        randoFactor = Random.Range(-0.5f, 0.5f);
        //laserShotCounter = laserShotLength;
    }

    // Update is called once per frame
    void Update()
    {

        if (moveTowardEnemyBase)
        {
            MoveTowardEnemyBase();
        }
        else
        {
            theRB.velocity = Vector3.zero;
        }

        if(turretLookAtTarget)
        {
            TurretLookAtTarget();
        }

        if (fireAtTarget)
        {
            FireAtTarget();
        }
        else
        {
            laserSR.enabled = false;
        }
            
    }

    public void UnitDeath()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "EnemyWall")
        {
            EnWall = other.GetComponent<EnemyWall>();
            moveTowardEnemyBase = false;
            targetPosition = other.transform;
            //turn turret
            //EnWall.unit = this;
            EnWall.units.Add(this);
            fireAtTarget = true;
            turret.transform.rotation = transform.rotation;
        }



        if(other.tag == "EnemyUnit")
        {



            turretLookAtTarget = true;
        }
    }

    public void MoveTowardEnemyBase()
    {
        

        moveDirection.x = (lm.lanes[lane].position.x + randoFactor) - transform.position.x;
        moveDirection.y += speed * Time.deltaTime;

        moveDirection.Normalize();

        theRB.velocity = moveDirection * speed;
    }

    public void TurretLookAtTarget()
    {
        Vector3 diff = targetPosition.position - turret.transform.position;
        diff.Normalize();
        float angle = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        turret.transform.rotation = Quaternion.Euler(0, 0, angle - 90);
    }

    public void FireAtTarget()
    {
        
        if(inBetweenShotCounter > 0)
        {
            inBetweenShotCounter -= Time.deltaTime;
        }

        if(inBetweenShotCounter <= 0)
        {
            laserSR.enabled = true;
            
            //play laser sound
            laserShotCounter = laserShotLength;
            inBetweenShotCounter = inBetweenShotLength;


            if (EnWall)
            {
                EnWall.DamageEnemyWall(laserDamage);
                laserSR.size = new Vector2(0.03f, 1f);
            }
            else
            {
                laserSR.size = new Vector2(0.03f, Vector3.Distance(transform.position, targetPosition.position));
                //!!!! maybe get rid of this else statement later? and put the code above on a future "if enemyunit" type deal !!!!!!
            }
        }


        if(laserShotCounter > 0)
        {
            laserShotCounter -= Time.deltaTime;
        }

        if(laserShotCounter <= 0)
        {
            laserSR.enabled = false;
        }

    }
}
