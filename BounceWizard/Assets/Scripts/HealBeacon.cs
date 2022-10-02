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
        HurtBox hurtbox = c.GetComponent<HurtBox>();
        if (!hurtbox) return;

        Heal(hurtbox.entity);
    }


    void Heal(Entity entity){

        entity.ChangeHealth(healAmt);
       
    }

}
