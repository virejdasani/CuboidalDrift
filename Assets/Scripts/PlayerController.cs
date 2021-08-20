using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float TouchMovementSpeed = 600f;

    public float keyboardMovementSpeed = 50000f;

    protected Joystick joystick;
    protected Rigidbody rb;

    void Start()
    {
        // Get the joystick
        joystick = FindObjectOfType<Joystick>();

        // Get the Rigidbody
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Check if the y position of the player is lower than 1. This is required because at he start of each level, the player falls from a high y value. Without this, the player can move in air and get out of the map
        if (rb.position.y < 2.5)
        {
            // Based on JoyStick input, move the rigidbody (player)
            rb.velocity = new Vector3(joystick.Horizontal * TouchMovementSpeed * Time.deltaTime,
                rb.velocity.y, joystick.Vertical * TouchMovementSpeed * Time.deltaTime);

            // Based on Keyboard input (WASD), move the rigidbody (player)
            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            rb.AddForce(move * Time.deltaTime * keyboardMovementSpeed);
        }

    }
}