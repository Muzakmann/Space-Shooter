using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {

    public float tumble;
    Rigidbody rb;
    public float speed;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = Random.insideUnitSphere * tumble;
        Vector3 movement = new Vector3(0.0f, 0.0f, speed);
        rb.velocity = movement;
       
    }


}
