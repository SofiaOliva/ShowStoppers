using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyShooter : MonoBehaviour
{
    public GameObject projectilePref;
    public float sightRange = 5f;
    public float castTime = 0.5f;
    public float projectileSpeed = 5f;
    public float cooldown = 2f;
    public float retryTime = 1f;

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
            if (TryShoot()){
                yield return new WaitForSeconds(cooldown);
            }
            else
            {
                yield return new WaitForSeconds(retryTime);
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

        //Shoot((targets[0].position - transform.position).normalized);
        //return true;
    }

    void Shoot(Vector3 direction)
    {
        Icicle projectile = Instantiate(projectilePref, transform.position, transform.rotation, transform).GetComponent<Icicle>();

        //projectile.Cast(direction*projectileSpeed, castTime);
        StartCoroutine(Casting(projectile, direction * projectileSpeed));
    }

    IEnumerator Casting(Icicle projectile, Vector3 velocity)
    {
        projectile.transform.rotation = Quaternion.LookRotation(velocity, Vector3.up);
        float prog = 0f;
        while(prog < 1f)
        {
            prog += Time.fixedDeltaTime/castTime;
            projectile.transform.position = transform.position;

            yield return new WaitForFixedUpdate();
        }
        projectile.Send(velocity);
    }
}
