using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float TouchMovementSpeed = 600f;

    public float keyboardMovementSpeed = 50000f;

    protected Joystick joystick;
    protected Rigidbody rb;

    private bool boosting;
    private float boostTimer;

    void Start()
    {
        // Get the joystick
        joystick = FindObjectOfType<Joystick>();

        // Get the Rigidbody
        rb = GetComponent<Rigidbody>();

        // Initially, it isn't boosting
        boosting = false;
    }

    void FixedUpdate()
    {
        // Check if the y position of the player is lower than 2.5. This is required because at he start of each level, the player falls from a high y value. Without this, the player can move in air and get out of the map
        if (rb.position.y < 2.3)
        {
            // Based on JoyStick input, move the rigidbody (player)
            rb.velocity = new Vector3(
                    joystick.Horizontal * TouchMovementSpeed * Time.deltaTime,
                    rb.velocity.y,
                    joystick.Vertical * TouchMovementSpeed * Time.deltaTime
                );

            // Based on Keyboard input (WASD), move the rigidbody (player)
            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            rb.AddForce(move * Time.deltaTime * keyboardMovementSpeed);
        }

        // This is true when player collides with BoostTriggerCube
        if (boosting)
        {
            // Start the timer for the number of seconds that the player will boost
            boostTimer += Time.deltaTime;

            // If it has been over 1 second
            if (boostTimer > 1)
            {
                // Stop boosting
                boosting = false;

                // Set the timer back to 0
                boostTimer = 0;
            }

            // While the timer hasn't run out
            else
            {
                rb.velocity = new Vector3(
                        joystick.Horizontal * TouchMovementSpeed * Time.deltaTime * 2,
                        rb.velocity.y,
                        1200 * Time.deltaTime
                    );
            }
        }

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "BoostTriggerCube")
        {
            boosting = true;
        }
    }
}