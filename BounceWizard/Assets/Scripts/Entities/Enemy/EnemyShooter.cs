using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyShooter : MonoBehaviour
{
    public GameObject projectilePref;
    public float sightRange = 5f;
    [Tooltip("How long between when the projectile is spawned and when it is launched")]
    public float castTime = 0.5f;
    public float projectileSpeed = 5f;
    [Tooltip("How long to wait between throws")]
    public Vector2 cooldownRange = new Vector2(4f,10f);
    [Tooltip("When no good throw is calculated, how long to wait before trying to throw again")]
    public Vector2 retryTimeRange = new Vector2(0.8f,1.5f);

    public Animator animator;
    LayerMask targetMask;
    Rigidbody rb;

    private void Awake()
    {
        targetMask = LayerMask.GetMask("Player", "Ally");
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        StartCoroutine(Shooting());
    }

    IEnumerator Shooting()
    {
        while (true)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(cooldownRange.x, cooldownRange.y));

            while(!TryShoot()){
                yield return new WaitForSeconds(UnityEngine.Random.Range(retryTimeRange.x, retryTimeRange.y));
            }
            
        }
    }

    bool TryShoot()
    {
        Collider[] colliderTargets = Physics.OverlapSphere(transform.position, sightRange, targetMask);
        if (colliderTargets.Length == 0) return false;
        Rigidbody[] targets = Array.ConvertAll<Collider, Rigidbody>(colliderTargets, item => item.attachedRigidbody);

        Vector3 aimDirection;

        if(PredictAim.TryAim(rb, targets, out aimDirection, projectileSpeed, castTime))
        {
            Shoot(aimDirection);
            return true;
        }
        else
        {
            return false;
        }
    }

    void Shoot(Vector3 direction)
    {
        Icicle projectile = Instantiate(projectilePref, transform.position, transform.rotation, transform).GetComponent<Icicle>();
        StartCoroutine(Casting(projectile, direction * projectileSpeed));
    }

    //Keep the projectile on top of the shooter until the cast time finishes
    IEnumerator Casting(Icicle projectile, Vector3 velocity)
    {
        animator.SetBool("charging", true);
        projectile.transform.rotation = Quaternion.LookRotation(velocity, Vector3.up);
        float prog = 0f;
        while(prog < 1f)
        {
            prog += Time.fixedDeltaTime/castTime;
            projectile.transform.position = transform.position;

            yield return new WaitForFixedUpdate();
        }
        projectile.Send(velocity);
        animator.SetBool("charging", false);
    }
}
