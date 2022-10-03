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

    void Start()
    {
        spawnSound?.Play(transform.position);
    }

    private void OnTriggerStay(Collider other)
    {
        HurtBox hurtbox = other.GetComponent<HurtBox>();
        if (!hurtbox) return;

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
