using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FaceForward : MonoBehaviour
{
    [SerializeField]
    Transform turnObject;
    [SerializeField]
    float maxTurnSpeed = 180f;
    [SerializeField]
    AnimationCurve turnCurve;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float currentAngle = Vector3.Angle(turnObject.forward, rb.velocity);
        float turnSpeed = turnCurve.Evaluate(currentAngle / 180f)*maxTurnSpeed;
        Vector3 newForward = Vector3.RotateTowards(turnObject.forward, rb.velocity, turnSpeed * Mathf.Deg2Rad *Time.deltaTime, 0f);
        turnObject.rotation = Quaternion.LookRotation(newForward, Vector3.up);
    }

}
