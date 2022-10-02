using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : HitGiver
{
    public SoundSO castSound;
    public GameObject explodeEffect;

    private void OnEnable()
    {
        SoundManager.Play(castSound, transform.position);
    }

    protected override void OnHit(Entity entity)
    {
        Instantiate(explodeEffect, entity.transform.position, Quaternion.identity);
    }
}
