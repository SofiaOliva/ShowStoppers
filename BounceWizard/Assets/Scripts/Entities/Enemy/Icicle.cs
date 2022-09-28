using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icicle : MonoBehaviour
{
    Rigidbody rb;
    HitGiver hitGiver;
    public Collider physicCollider;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        hitGiver = GetComponent<HitGiver>();
        hitGiver.SetActive(false);
        physicCollider.enabled = false;
    }

    public void Cast(Vector3 velocity, float castTime)
    {
        rb.rotation = Quaternion.LookRotation(velocity, Vector3.up);
        StartCoroutine(Casting(velocity, castTime));
    }

    IEnumerator Casting(Vector3 velocity, float castTime)
    {
        yield return new WaitForSeconds(castTime);
        Send(velocity);
    }

    public void Send(Vector3 velocity)
    {
        transform.SetParent(null);
        StartCoroutine(Enabling());
        rb.rotation = Quaternion.LookRotation(velocity, Vector3.up);
        rb.velocity = velocity;
        hitGiver.SetActive(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

    IEnumerator Enabling()
    {
        yield return new WaitForSeconds(0.5f);
        physicCollider.enabled = true;
    }

}
