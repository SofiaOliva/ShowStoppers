using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider c)
    {
        Rigidbody rb = c.attachedRigidbody;
        
        if(rb == null){
            return;
        }

        Entity entity = c.attachedRigidbody.GetComponent<Entity>();

        if(entity == null){
            return;
        }

        entity.TakeDamage(damage);
        Destroy(gameObject);
    }
}