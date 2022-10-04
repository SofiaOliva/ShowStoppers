using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SpeedController : MonoBehaviour
{
    [SerializeField]
    float speed = 1f;

    [SerializeField]
    float acceleration = 1f;
    [SerializeField]
    float deacceleration = 1f;
    float maxSpeed = 5f;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if(rb.velocity.sqrMagnitude == 0f)
        {
            rb.velocity = Quaternion.Euler(0f,Random.Range(0f,1f)*180f,0f) * Vector3.forward;
        }
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

        if (currentSpeed > maxSpeed)
        {
            rb.velocity = currentDirection * maxSpeed;
        }
            
    }
}
