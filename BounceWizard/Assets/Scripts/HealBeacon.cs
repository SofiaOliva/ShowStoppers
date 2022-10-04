using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBeacon : MonoBehaviour
{
    // Placehold 1
    [Tooltip("Initial burst of healing when entity enters aura for the first time")]
    public int healAmt = 1;
    [Tooltip("How many seconds before blessed entity recovers a health point")]
    public float healTime = 3f;

    public GameObject blessedEffectPref;
    public SoundSO spawnSound;
    public GameObject beaconExplodeEffect;


    void Start()
    {
        spawnSound?.Play(transform.position);
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Explode(){
        // Explodes the beacon
        Instantiate(beaconExplodeEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerStay(Collider other)
    {
        HurtBox hurtbox = other.GetComponent<HurtBox>();
        Rigidbody otherRigidbody = other.attachedRigidbody;
        
        if (hurtbox)
        {
            Heal(hurtbox.entity);
        }
        else if (otherRigidbody)
        {
            Fireball fireballScript = otherRigidbody.GetComponent<Fireball>();
            if (!fireballScript) return;
            Destroy(fireballScript.gameObject);
            Explode();
        }
    }

    void Heal(Entity entity){
        if (!entity.blessed)
        {
            entity.ChangeHealth(healAmt);
            entity.blessed = true;
            Instantiate(blessedEffectPref, entity.transform.position, Quaternion.identity, entity.transform);
        }
        else
        {
            entity.ChangeHealth(Time.fixedDeltaTime/healTime);
        }
       
    }

}
