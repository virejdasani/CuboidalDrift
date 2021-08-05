using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 100f;
    public Vector3 jumpForce;

    protected Joystick joystick;
    protected Rigidbody rb;

    // This is because the player doesn't start on the ground. It falls on the ground when game starts
    bool isGrounded = false;

    void Start()
    {
        joystick = FindObjectOfType<Joystick>();

        // Get the Rigidbody
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Based on JoyStick input, add velocity to the rigidbody
        rb.velocity = new Vector3(joystick.Horizontal * movementSpeed,
            rb.velocity.y, joystick.Vertical * movementSpeed);

        // For jumping, first check if there is any touch input
        if (Input.touchCount > 0)
        {
            // Now check if player is touching the ground
            if (isGrounded)
            {
                // Now, check if the touch is in the right half of the screen
                if (Input.GetTouch(Input.touchCount - 1).position.x > Screen.width / 2)
                    // Add force to the player in the y direction
                    rb.AddForce(jumpForce);
            }

        }

    }

    // To detect collisions for player jumping
    void OnCollisionEnter(Collision collision)
    {
        // If the player just touched a surface, isGrounded = true
        if (collision.gameObject.tag == "Surface")
        {
            isGrounded = true;
        }
    }

    // If player just exited touching a surface, isGrounded = false
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Surface")
        {
            isGrounded = false;
        }
    }
}