using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float TouchMovementSpeed = 500f;
    public Vector3 touchJumpForce;

    public float keyboardMovementSpeed = 50000f;
    public float keyboardJumpForce = 10000f;

    protected Joystick joystick;
    protected Rigidbody rb;

    // This is because the player doesn't start on the ground. It falls on the ground when game starts
    bool isGrounded = false;

    void Start()
    {
        // Get the joystick
        joystick = FindObjectOfType<Joystick>();

        // Get the Rigidbody
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Based on JoyStick input, move the rigidbody (player)
        rb.velocity = new Vector3(joystick.Horizontal * TouchMovementSpeed * Time.deltaTime,
            rb.velocity.y, joystick.Vertical * TouchMovementSpeed * Time.deltaTime);

        // Based on Keyboard input (WASD), move the rigidbody (player)
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rb.AddForce(move * Time.deltaTime * keyboardMovementSpeed);

        // For jumping, first check if there is any touch input
        if (isGrounded)
        {
            // Now check if player is touching the ground
            if (Input.touchCount > 0)
            {
                // Now, check if the touch is in the right half of the screen
                if (Input.GetTouch(Input.touchCount - 1).position.x > Screen.width / 2)
                    // Add force to the player in the y direction
                    rb.AddForce(touchJumpForce);
            }

            // When space bar is pressed, jump
            Vector3 jump = new Vector3(0, Input.GetAxis("Jump"), 0);
            rb.AddForce(jump * Time.deltaTime * keyboardJumpForce);

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