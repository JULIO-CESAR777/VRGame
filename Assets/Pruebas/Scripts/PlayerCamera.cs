using System;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float mouseSensitivity = 1000f;

    public Transform playerBody;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // Inputs
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * mouseSensitivity;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * mouseSensitivity;

        playerBody.Rotate(Vector3.up * mouseX);
        //rotationY += mouseX;
        //rotationX -= mouseY;
        //// Limit to the camera
        //rotationX = Mathf.Clamp(rotationX, -90, 90);
        
        //// Rotate the camera and orientation
        //transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
        //orientation.rotation = Quaternion.Euler(0, rotationY, 0);
    }
}
