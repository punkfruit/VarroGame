using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController2 : MonoBehaviour
{
    public GameObject picker;
    public bool pickerActive = false;

    // Start is called before the first frame update
    void Start()
    {
        picker.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            ShowDefenderSpawnerWindow();
        }
    }


    public void ShowDefenderSpawnerWindow()
    {
        if (pickerActive)
        {
            picker.SetActive(false);
            pickerActive = false;

        }
        else
        {
            picker.SetActive(true);
            pickerActive = true;
            //picker.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            picker.transform.position = new Vector3(pos.x, pos.y, 0);
        }
    }
}
