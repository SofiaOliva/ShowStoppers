using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitGiver : MonoBehaviour
{
    public int damage = 1;
    public SoundSO castSound;
    public SoundSO hitSound;
    bool active = true;

    private void OnEnable()
    {
        castSound?.Play(transform.position);
    }

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

    public virtual void HitEntity(Entity entity)
    {
        entity.TakeDamage(damage);
        active = false;
        OnHit(entity);
        Destroy(gameObject);
    }

    protected virtual void OnHit(Entity entity)
    {
        hitSound?.Play(transform.position);
    }
}
