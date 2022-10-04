using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public GameObject fireball;
    public float fireBallStartDistance = 1.25f;
    public float fireballCastCooldownTime = 0.1f;
    private float fireballCastCooldownProgress = 0f;
    public GameObject beaconSeedPrefab;
    public float dashSpeed = 1.5f;
    
    Rigidbody rb;

    public ManaPool manaPool;
    public Animator animator;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        if (PauseManager.isPaused || !GameManager.levelPlaying) return;
        if (Input.GetKey(KeyCode.Mouse0))
        {
            TryCastFireball();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1)) 
        {
            TryThrowBeacon();  
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            startDashSpell();
        }
    }

    private void FixedUpdate()
    {
        fireballCastCooldownProgress = Mathf.Max(0f, fireballCastCooldownProgress - Time.fixedDeltaTime / fireballCastCooldownTime);
    }

    protected override void OnHit()
    {
        base.OnHit();
        animator.SetTrigger("hit");
    }

    void TryCastFireball()
    {
        if (fireballCastCooldownProgress > 0f) return;
        if (!manaPool.TryCast(0)) return;

        fireballCastCooldownProgress = 1f;

        LaunchFireball();
    }

    void LaunchFireball()
    {
        animator.SetTrigger("shootFire");
        Vector3 aimPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        aimPosition = new Vector3(aimPosition.x, 0, aimPosition.z);
        

        Vector3 aimDirection = (aimPosition - transform.position).normalized;
        Vector3 spawnPosition = transform.position + aimDirection * fireBallStartDistance;
        bool spawnedInWall = InWall(spawnPosition);
        GameObject newFireball = Instantiate(fireball, spawnPosition, Quaternion.identity);
        newFireball.GetComponent<Rigidbody>().velocity = aimDirection;

        if (spawnedInWall)
        {
            newFireball?.GetComponent<Fireball>()?.HitEntity(this);
        }
    }

    void TryThrowBeacon()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPosition = new Vector3(worldPosition.x, 0, worldPosition.z);

        if (InWall(worldPosition)) return;

        if (!manaPool.TryCast(1)) return;

        ThrowBeacon(worldPosition);
    }
    void ThrowBeacon(Vector3 worldPosition)
    {
        animator.SetTrigger("shootBeacon");
        BeaconSeed beaconSeed = Instantiate(beaconSeedPrefab, transform.position, Quaternion.identity).GetComponent<BeaconSeed>();
        beaconSeed.ThrowTo(worldPosition);
    }
    void startDashSpell()
    {
        Vector3 aimPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        aimPosition = new Vector3(aimPosition.x, 0, aimPosition.z);

        Vector3 aimDirection = (aimPosition - transform.position).normalized;
        Vector3 spawnPosition = transform.position + aimDirection;
        if (InWall(spawnPosition)) return;
        if (!manaPool.TryCast(2)) return;

        rb.velocity = aimDirection * dashSpeed;

        transform.position = new Vector3(spawnPosition.x, 0, spawnPosition.z);
    }
    bool InWall(Vector3 pos)
    {
        Collider[] walls = Physics.OverlapSphere(pos, 0.25f, LayerMask.GetMask("Wall"));
        return walls.Length > 0;
    }
}
