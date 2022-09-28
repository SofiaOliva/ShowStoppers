using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBeacon : MonoBehaviour
{
    // Placehold 1
    public int healAmt = 1; 

    // Start is called once
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Do we update anything?
    }

    void OnTriggerEnter(Collider c)
    {
        // Line 30 requires rigidbody
        Rigidbody rb = c.attachedRigidbody;
        
        if(rb == null){
            return;
        }

        Entity entity = c.attachedRigidbody.GetComponent<Entity>();

        if(entity == null){
            return;
        }

        Heal(entity);
    }


    void Heal(Entity entity){

        entity.ChangeHealth(healAmt);
       
    }

}
