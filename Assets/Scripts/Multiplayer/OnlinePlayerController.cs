using UnityEngine;
using Photon.Pun;

public class OnlinePlayerController : MonoBehaviour
{
    public float TouchMovementSpeed = 600f;
    //public Vector3 touchJumpForce;

    public float keyboardMovementSpeed = 50000f;
    //public float keyboardJumpForce = 10000f;

    protected Joystick joystick;
    protected Rigidbody rb;

    PhotonView view;

    void Start()
    {
        // Get the joystick
        joystick = FindObjectOfType<Joystick>();

        // Get the Rigidbody
        rb = GetComponent<Rigidbody>();

        // Get the photon view component attached to online player
        view = GetComponent<PhotonView>();
    }

    void FixedUpdate()
    {
        // This is to make sure each player can control only their cube
        if (view.IsMine)
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
}