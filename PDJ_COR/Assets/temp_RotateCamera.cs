using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class temp_RotateCamera : MonoBehaviour
{
    public float rotationSpeed = 2.0f; // Adjust this value to control the rotation speed

    public CinemachineVirtualCamera virtualCamera;
    void Start(){
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    void Update()
    {
        if (virtualCamera != null)
        {
            // Get the mouse input
            float mouseX = Input.GetAxis("Mouse X");

            // Calculate the rotation amount based on mouse input
            float rotationAmount = mouseX * rotationSpeed;

            // Update the Y axis rotation of the camera's transform
            transform.Rotate(0, rotationAmount, 0);
        }  
    }
}
