using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : HitGiver
{
    public SoundSO castSound;

    private void OnEnable()
    {
        SoundManager.Play(castSound, transform.position);
    }
}
