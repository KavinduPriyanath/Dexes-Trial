using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W2Movements : MonoBehaviour
{
    public float speed = 12f;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float x = Input.GetAxis("Horizontal") * speed;
        float z = Input.GetAxis("Vertical") * speed;

        rb.velocity = (transform.forward * z) + (transform.right * x) + (transform.up * rb.velocity.y);
    }
}
