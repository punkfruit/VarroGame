using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{

    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        pos.y += speed * Time.deltaTime; //to be changed later
        transform.position = pos;
    }

    public void UnitDeath()
    {
        Destroy(gameObject);
    }
}
