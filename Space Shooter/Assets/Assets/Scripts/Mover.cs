using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Vector3 movement = new Vector3(0.0f, 0.0f, speed);
        rb.velocity = movement;

    }

    

}
