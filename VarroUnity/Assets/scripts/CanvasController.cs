using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public GameObject[] nubs;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject nub in nubs)
        {
            nub.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NubControl(int numb)
    {
        foreach (GameObject nub in nubs)
        {
            nub.gameObject.SetActive(false);
        }

        nubs[numb].gameObject.SetActive(true);
    }
}
