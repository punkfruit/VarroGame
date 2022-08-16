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

    void Start()
    {
        lm = FindObjectOfType<LaneMarkers>();
        lane = Random.Range(0, lm.lanes.Length);
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

        if(targetPosition != null)
        {
            TurretLookAtTarget();
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
            EnWall.unit = this;
        }
    }

    public void MoveTowardEnemyBase()
    {
        /*
       Vector3 pos = transform.position;

       pos.y += speed * Time.deltaTime; //to be changed later
       //pos.x += lm.lanes[lane].position.x;
       //pos.MoveTowards(transform.position, lm.lanes[lane].transform, speed * Time.deltaTime);
       if(transform.position.x != lm.lanes[lane].position.x)

       pos.Normalize();
       transform.position = pos;
       */

        moveDirection.x = lm.lanes[lane].position.x - transform.position.x;
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
}
