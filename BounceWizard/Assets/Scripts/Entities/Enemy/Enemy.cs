using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public Animator animator;

    protected override void OnHit()
    {
        base.OnHit();
        animator.SetTrigger("hit");
    }
}
