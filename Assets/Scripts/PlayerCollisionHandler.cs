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
        // HomePage Scene
        if (collision.gameObject.name == "PlayCube")
        {
            // This (Initiate.Fade) function in from the simple fade scene asset (from asset store)
            // It does this: "SceneManager.LoadScene("Levels");" and also adds transition animation to current scene and the scene we are transitioning to
            Initiate.Fade("Levels", Color.black, fadeSpeed);
        }

        else if (collision.gameObject.name == "AboutCube")
        {
            SceneManager.LoadScene("About");
        }
        // HomePage Scene End


        // Levels Scene
        else if (collision.gameObject.name == "BackToHomeCube")
        {
            Initiate.Fade("HomePage", Color.black, fadeSpeed);
        }
        // Levels Scene End


    }
}
