using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public bool charging = false;
    public Rigidbody rb;
    public float speed = 0.5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            charging = true;
        }

        if (charging)
        {
            rb.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
        }
    }
    //private void FixedUpdate()
    //{
    //    if (charging)
    //    {
    //        rb.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
        charging = false;
    }
}
