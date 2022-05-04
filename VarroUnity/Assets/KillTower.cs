using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTower : MonoBehaviour
{
    public float life = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        life -= Time.deltaTime;

        if (life <= 0)
        {
            DieLol();
        }
    }

    /*
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Tower")
        {
            other.GetComponent<Defender>().Die();
            DieLol();
        }
    }
    */

    private void DieLol()
    {
        Destroy(gameObject);
    }
}
