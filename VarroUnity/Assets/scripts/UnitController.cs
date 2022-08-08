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
    // Start is called before the first frame update
    void Start()
    {
        lm = FindObjectOfType<LaneMarkers>();
        lane = Random.Range(0, lm.lanes.Length);
    }

    // Update is called once per frame
    void Update()
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

    public void UnitDeath()
    {
        Destroy(gameObject);
    }
}
