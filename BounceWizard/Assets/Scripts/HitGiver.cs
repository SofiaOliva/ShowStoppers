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
        Rigidbody rb = c.attachedRigidbody;

        if (rb == null)
        {
            return;
        }

        Entity entity = c.attachedRigidbody.GetComponent<Entity>();

        if (entity == null)
        {
            return;
        }

        HitEntity(entity);
    }

    public void HitEntity(Entity entity)
    {
        entity.TakeDamage(damage);
        active = false;
        Destroy(gameObject);
    }
}
