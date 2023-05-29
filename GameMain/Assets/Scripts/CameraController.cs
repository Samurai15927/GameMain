using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    Camera mainCamera;
    public float vertSensitivity;
    public float xRotation;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y") * vertSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);


     
       


    }
}