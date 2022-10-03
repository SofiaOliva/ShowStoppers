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

    public ManaPool manaPool;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            TryCastFireball();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1)) 
        {
            CreateBeacon();  
        }
        
    }

    private void FixedUpdate()
    {
        fireballCastCooldownProgress = Mathf.Max(0f, fireballCastCooldownProgress - Time.fixedDeltaTime / fireballCastCooldownTime);
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

    void CreateBeacon()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPosition = new Vector3(worldPosition.x, 0, worldPosition.z);

        if (InWall(worldPosition)) return;

        if (!manaPool.TryCast(1)) return;

        BeaconSeed beaconSeed = Instantiate(beaconSeedPrefab, transform.position, Quaternion.identity).GetComponent<BeaconSeed>();
        beaconSeed.ThrowTo(worldPosition);
    }

    bool InWall(Vector3 pos)
    {
        Collider[] walls = Physics.OverlapSphere(pos, 0.25f, LayerMask.GetMask("Wall"));
        return walls.Length > 0;
    }
}
