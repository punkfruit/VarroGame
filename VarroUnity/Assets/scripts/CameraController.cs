using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera cam;
    public float minSize = 1, maxSize = 10;
    public float minSpeed = 5, maxSpeed = 12;
    public float panSpeed = 20f;
    public float zoomSpeed = 2f; // You can adjust this value as needed
    public Vector2 panLimit;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey(KeyCode.W))
        {
            pos.y += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            pos.y -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            pos.x += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            pos.x -= panSpeed * Time.deltaTime;
        }

        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        pos.y = Mathf.Clamp(pos.y, -panLimit.y, panLimit.y);

        transform.position = pos;

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            Vector3 worldMousePositionBeforeZoom = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.transform.position.z * -1));

            float newSize = Mathf.Clamp(cam.orthographicSize - scroll * zoomSpeed, minSize, maxSize);
            float speedFactor = Mathf.Lerp(minSpeed, maxSpeed, (newSize - minSize) / (maxSize - minSize));
            panSpeed = speedFactor;
            cam.orthographicSize = newSize;

            Vector3 worldMousePositionAfterZoom = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.transform.position.z * -1));

            Vector3 difference = worldMousePositionBeforeZoom - worldMousePositionAfterZoom;
            difference.z = 0;

            cam.transform.position += difference;
        }


        if (Input.GetMouseButton(2))
        {
            pos.x -= Input.GetAxis("Mouse X") * panSpeed * 10 * Time.deltaTime;
            pos.y -= Input.GetAxis("Mouse Y") * panSpeed * 10 * Time.deltaTime;
            pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
            pos.y = Mathf.Clamp(pos.y, -panLimit.y, panLimit.y);
            transform.position = pos;
        }

    }
}

