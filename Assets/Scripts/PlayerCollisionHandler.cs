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
        if (collision.gameObject.name == "PlayCube")
        {
            SceneManager.LoadScene("Levels");
        }

        else if (collision.gameObject.name == "AboutCube")
        {
            SceneManager.LoadScene("About");
        }
    }
}
