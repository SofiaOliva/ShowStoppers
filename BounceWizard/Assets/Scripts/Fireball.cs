using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : HitGiver
{
    public GameObject explodeEffect;
    bool hasBounced = false;

    protected override void OnHit(Entity entity)
    {
        base.OnHit(entity);
        Instantiate(explodeEffect, entity.transform.position, Quaternion.identity);
    }

    public override void HitEntity(Entity entity)
    {
        if (!hasBounced && entity.GetComponent<Player>() != null)
        {
            return;
        }
        base.HitEntity(entity);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (hasBounced) return;
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player")) return;
        hasBounced = true;
    }
}
