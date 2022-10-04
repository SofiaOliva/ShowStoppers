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

      public void Explode(Collider other){
        // Explodes the beacon
        Instantiate(beaconExplodeEffect, other.transform.position, Quaternion.identity);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }

    private void OnTriggerStay(Collider other)
    {
        HurtBox hurtbox = other.GetComponent<HurtBox>();
        Fireball fireballScript = other.attachedRigidbody.GetComponent<Fireball>();

        if (!hurtbox) {
            if(fireballScript != null)
            Explode(other);
            else
                return;
        return;
        }

        Heal(hurtbox.entity);
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
