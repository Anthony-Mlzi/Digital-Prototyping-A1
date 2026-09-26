using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // How fast the player jumps
    private float jumpSpeed = 350f;
    // The players current move speed
    private float moveSpeed = 2f;
    // Acceleration applied to move speed over period of time during movement
    private float acceleration = 15f;
    // Direction of movement
    private Vector3 moveDirection;
    // Check for grounded
    private bool isGrounded = false;
    // Check for Movement
    public bool isMoving = false;

    Rigidbody rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        // Function to handle all player movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calculate movement direction of player
        moveDirection = new Vector3(horizontal, 0f, vertical).normalized;

        // If player is moving, apply acceleration
        if (horizontal != 0 || vertical != 0)
        {
            isMoving = true;

            // calculate acceleration
            moveSpeed += acceleration * Time.deltaTime;

            Debug.Log(moveSpeed);

            // Cap move speed
            if (moveSpeed > 8)
            {
                moveSpeed = 8;
            }
        }
        else
        {
            //Reset all acceleration if player stops moving

            isMoving = false;

            acceleration = 15f;

            moveSpeed = 2f;
        }

        // translate all player movement compenents into character controller
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        if (Input.GetKeyDown("space") && isGrounded)
        {
            moveSpeed -= 6f;

            Debug.Log("JUMP");

            rb.AddForce(Vector3.up * jumpSpeed);
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}

