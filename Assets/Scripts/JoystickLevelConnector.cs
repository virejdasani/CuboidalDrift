using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickLevelConnector : MonoBehaviour
{
    public float movementSpeed = 100f;

    protected Joystick joystick;
    protected Rigidbody rigid;

    void Start()
    {
        joystick = FindObjectOfType<Joystick>();

        // Get the rigidbody
        rigid = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Add velocity to the rigidbody. In this game, the player is stationary at 0,0,0 and the level is moved based on joystick input
        rigid.velocity = new Vector3(joystick.Horizontal * movementSpeed,
            rigid.velocity.y, joystick.Vertical * movementSpeed);
    }
}
