using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public ShakeSO hurtScreenShake;

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        hurtScreenShake?.DoShake();
    }
}
