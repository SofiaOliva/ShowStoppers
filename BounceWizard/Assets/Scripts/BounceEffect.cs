using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceEffect : MonoBehaviour
{
    public Transform bounceT;
    public float bounceTime = 0.2f;
    public float bounceMagnitude = 1f;
    Vector3 bounceScale = new Vector3(0.4f, 2f, 0.4f);
    public AnimationCurve bounceCurve;

    Vector3 startScale;
    float bounceProg = 0f;
    public GameObject bumpEffect;
    public SoundSO bounceSound;

    private void Start()
    {
        startScale = transform.localScale;
    }

    private void OnCollisionEnter(Collision collision)
    {
        bounceProg = 1f;
        ContactPoint point = collision.GetContact(0);
        Instantiate(bumpEffect, point.point, Quaternion.LookRotation(point.normal, Vector3.up));
        if(bounceSound) SoundManager.Play(bounceSound, transform.position);
    }

    private void Update()
    {
        bounceT.transform.localScale = Vector3.Scale(startScale, Vector3.Lerp(Vector3.one, bounceScale* bounceMagnitude, bounceCurve.Evaluate(1f-bounceProg)));
        bounceProg = Mathf.Max(0f, bounceProg - Time.deltaTime/bounceTime);
    }
}
