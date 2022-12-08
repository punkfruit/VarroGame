using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera cam;
    public float minSize = 1, maxSize = 10;
    public float minSpeed = 5, maxSpeed = 12;
    public float panSpeed = 20f;
    public float panBorderThickness = 10f;
    public Vector2 panLimit;

    /*
    // The speed at which the camera pans around the scene
    public float panSpeed2 = 10f, divisionNumb = 100f;

    private float halfHeight, halfWidth;


    private void Start()
    {
        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Camera.main.aspect;
    }
    */

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        if(Input.GetKey(KeyCode.W) || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            pos.y += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) || Input.mousePosition.y <=  panBorderThickness)
        {
            pos.y -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            pos.x += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A) || Input.mousePosition.x <= panBorderThickness)
        {
            pos.x -= panSpeed * Time.deltaTime;
        }

        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        pos.y = Mathf.Clamp(pos.y, -panLimit.y, panLimit.y);

        transform.position = pos;


        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            cam.orthographicSize--;
            panSpeed--;
            if(cam.orthographicSize < minSize)
            {
                cam.orthographicSize = minSize;
            }

            if (panSpeed < minSpeed)
            {
                panSpeed = minSpeed;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            cam.orthographicSize++;
            panSpeed++;
            if (cam.orthographicSize > maxSize)
            {
                cam.orthographicSize = maxSize;
            }

            

            if (panSpeed > maxSize)
            {
                panSpeed = maxSpeed;
            }

        }

        /*
        // Check if the middle mouse button is being held down
        if (Input.GetMouseButton(2))
        {
            // Get the current mouse position in screen space
            Vector3 mousePos = Input.mousePosition;

            // Calculate the movement of the mouse since the last frame
            Vector3 mouseDelta = mousePos - Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Camera.main.transform.position.z));

            // Update the camera's position based on the mouse movement
            transform.position += new Vector3((mouseDelta.x -halfWidth) / divisionNumb, (mouseDelta.y - halfHeight) / divisionNumb, 0) * panSpeed2;
        }
        */
    }
}
