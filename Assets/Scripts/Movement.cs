using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] public CharacterController controller;
    [SerializeField] public float speed = 12f;
    [SerializeField] public float gravity = -9.81f;
    [SerializeField] public float jumpHeight = 3f;

    [SerializeField] public Transform groundCheck; // Empty object on player called GroundCheck
    [SerializeField] public float groundDistance = 0.4f; // radius of ground check sphere
    [SerializeField] public LayerMask groundMask; // control what objects the sphere should check for



    Vector3 velocity;
    bool isGrounded;

    void Update()
    {
        // creates invisible sphere that checks if were on the ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // using -2 instead of 0 ensures the player gets put on the ground better
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // take the direction the player is facing and move from that direction (local movement)
        Vector3 move = transform.right * x + transform.forward * z; 

        controller.Move(move * speed * Time.deltaTime);

        // jump physics
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime); // physics of freefalling
    }
}
