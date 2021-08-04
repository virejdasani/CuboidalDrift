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
        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = new Vector3(joystick.Horizontal * movementSpeed * -1f,
            rigidbody.velocity.y, joystick.Vertical * movementSpeed * -1f);
    }
}
