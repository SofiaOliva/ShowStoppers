using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SpeedController : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;

    [SerializeField]
    float acceleration = 1f;
    [SerializeField]
    float deacceleration = 1f;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = rb.velocity.normalized * speed;
    }

    private void FixedUpdate()
    {
        if(rb.velocity.sqrMagnitude == 0f)
        {
            rb.velocity = Vector3.forward;
        }
        float currentSpeed = rb.velocity.magnitude;
        Vector3 currentDirection = rb.velocity.normalized;

        if(currentSpeed < speed)
        {
            rb.velocity = currentDirection * Mathf.Max(currentSpeed + acceleration*Time.fixedDeltaTime, speed);
        }
        else
        {
            rb.velocity = currentDirection * Mathf.Max(currentSpeed - deacceleration*Time.fixedDeltaTime, speed);
        }
    }
}
