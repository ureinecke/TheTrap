using UnityEngine;
using UnityEngine.VR;
using System.Collections;

public class CameraRotation : MonoBehaviour
{

    Camera camera;

    // Use this for initialization
    void Start()
    {
        camera = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (!VRSettings.enabled)
        {
            float rotationSpeed = 5.0f;
            float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
            camera.transform.rotation = camera.transform.rotation * Quaternion.Euler(-mouseY, 0, 0);
            transform.rotation = transform.rotation * Quaternion.Euler(0, mouseX, 0);
        }*/
    }
}