using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisionHandler : MonoBehaviour
{
    protected Rigidbody rb;

    // This is the transition time when changing scenes (Faster this number = less time for transition)
    public float fadeSpeed = 2.0f;

    void Start()
    {
        // Get the rigidbody
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "AboutCube")
        {
            // This (Initiate.Fade) function in from the simple fade scene asset (from asset store)
            // It does this: "SceneManager.LoadScene("Levels");" and also adds transition animation to current scene and the scene we are transitioning to
            Initiate.Fade("About", Color.black, fadeSpeed);
        }

        else if (collision.gameObject.name == "GoToHomeCube")
        {
            Initiate.Fade("HomePage", Color.black, fadeSpeed);
        }

        else if (collision.gameObject.name == "GoToLevelsCube")
        {
            Initiate.Fade("Levels", Color.black, fadeSpeed);
        }

        // Levels
        else if (collision.gameObject.name == "GoToLevel1")
        {
            Initiate.Fade("Level1", Color.black, fadeSpeed);
        }
    }
}
