using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitGiver : MonoBehaviour
{
    public int damage = 1;
    bool active = true;

    public void SetActive(bool value)
    {
        active = value;
    }

    void OnTriggerEnter(Collider c)
    {
        if (!active) return;
        HurtBox hurtbox = c.GetComponent<HurtBox>();
        if (!hurtbox) return;


        HitEntity(hurtbox.entity);
    }

    public void HitEntity(Entity entity)
    {
        entity.TakeDamage(damage);
        active = false;
        OnHit(entity);
        Destroy(gameObject);
    }

    protected virtual void OnHit(Entity entity)
    {

    }
}
