using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public GameObject fireball;
    public float fireBallStartDistance = 1.25f;
    public GameObject beacon;

    public ManaPool manaPool;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            LaunchFireball();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1)) 
        {
            CreateBeacon();  
        }
    }

    void LaunchFireball()
    {
        if (!manaPool.TryCast(0)) return;

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

        GameObject newBeacon = Instantiate(beacon, worldPosition, Quaternion.identity);
    }

    bool InWall(Vector3 pos)
    {
        Collider[] walls = Physics.OverlapSphere(pos, 0.25f, LayerMask.GetMask("Wall"));
        return walls.Length > 0;
    }
}
