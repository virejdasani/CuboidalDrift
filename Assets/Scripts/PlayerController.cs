using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 100f;
    public Vector3 jumpForce;

    protected Joystick joystick;
    protected Rigidbody rb;

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

        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).position.x > Screen.width / 2)
            rb.AddForce(jumpForce);
            Debug.Log("touched");
            Debug.Log(Input.GetTouch(0).position);
        }

        // This is the touch input with mouse (left click)
        //if (Input.GetMouseButtonDown(0))
        //{
        //    rb.AddForce(jumpForce);
        //}
    }
}
