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
        rb.velocity = new Vector3(1f, 0f, 1f);
    }

    private void FixedUpdate()
    {
        if(rb.velocity.sqrMagnitude == 0f)
        {
            rb.velocity = Vector3.up;
        }
        float currentSpeed = rb.velocity.magnitude;
        Vector3 currentDirection = rb.velocity.normalized;

        if(currentSpeed < speed)
        {
            rb.velocity = currentDirection * Mathf.Max(currentSpeed + acceleration, speed);
        }
        else
        {
            rb.velocity = currentDirection * Mathf.Max(currentSpeed - deacceleration, speed);
        }
    }
}
