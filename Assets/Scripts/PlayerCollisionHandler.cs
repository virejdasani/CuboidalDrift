using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisionHandler : MonoBehaviour
{
    protected Rigidbody rb;

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
            SceneManager.LoadScene("Levels");
        }

        else if (collision.gameObject.name == "AboutCube")
        {
            SceneManager.LoadScene("About");
        }
        // HomePage Scene End

        // Levels Scene
        else if (collision.gameObject.name == "BackToHomeCube")
        {
            SceneManager.LoadScene("HomePage");
        }
        // Levels Scene End


    }
}
