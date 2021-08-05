using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    protected Rigidbody rb;

    void Start()
    {
        // Get the rbbody
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        
    }
}
