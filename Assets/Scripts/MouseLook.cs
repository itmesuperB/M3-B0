using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] public float mouseSensitivity = 100f;
    [SerializeField] public Transform playerBody;

    [SerializeField] float xRotation = 0f; // look up and down

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // lock cursor to center of screen
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Make sure you can't look 360degrees around

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // keep track of  X rotation (up and down)
        playerBody.Rotate(Vector3.up * mouseX); // look left and right along Xaxis
    }
}
