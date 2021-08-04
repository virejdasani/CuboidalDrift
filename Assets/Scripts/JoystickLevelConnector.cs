using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickLevelConnector : MonoBehaviour
{
    public float movementSpeed = 100f;

    protected Joystick joystick;

    void Start()
    {
        joystick = FindObjectOfType<Joystick>();   
    }

    void Update()
    {
        // Get the rigidbody
        var rigidbody = GetComponent<Rigidbody>();

        // Add velocity to the rigidbody. In this game, the player is stationary at 0,0,0 and the level is moved based on joystick input
        rigidbody.velocity = new Vector3(joystick.Horizontal * movementSpeed * -1f,
            rigidbody.velocity.y, joystick.Vertical * movementSpeed * -1f);
    }
}
