using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGridLayout : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        BaseLayout();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BaseLayout()
    {
        float i = 0;
        foreach (Transform child in transform)
        {
            i += 1;
            child.transform.position += new Vector3(i, 0, 0);
        }
    }
}
