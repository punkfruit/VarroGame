using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController2 : MonoBehaviour
{
    public GameObject picker;
    //public bool pickerActive = false;

    public TestDefenderPreview prev;

    // Start is called before the first frame update
    void Start()
    {
        picker.SetActive(false);
        if(prev != null)
            prev = FindObjectOfType<TestDefenderPreview>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2") && !GameManager.instance.isPaused) //when you click your right mouse button, aslong as the game isnt paused, show the defender spawner window!
        {
            ShowDefenderSpawnerWindow();
        }
    }


    public void ShowDefenderSpawnerWindow()
    {
        if (picker.activeInHierarchy)
        {
            picker.SetActive(false);
            //pickerActive = false;

        }
        else
        {
            picker.SetActive(true);
            //pickerActive = true;
            //picker.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            picker.transform.position = new Vector3(pos.x, pos.y, 0);
        }
    }

    public void SetPreviewSprite(int index)
    {
        prev.SetPreSpri(index);
    }
}
