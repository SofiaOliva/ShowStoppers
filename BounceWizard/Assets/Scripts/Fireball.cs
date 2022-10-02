using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : HitGiver
{
    public GameObject explodeEffect;

    protected override void OnHit(Entity entity)
    {
        base.OnHit(entity);
        Instantiate(explodeEffect, entity.transform.position, Quaternion.identity);
    }
}
