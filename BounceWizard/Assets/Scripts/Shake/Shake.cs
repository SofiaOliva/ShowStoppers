using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Shake
{
    public float magnitude = 1f;
    public float duration = 0.25f;
    [HideInInspector]
    public float prog = 0f;

    public static void Copy(Shake target, Shake source)
    {
        target.magnitude = source.magnitude;
        target.duration = source.duration;
    }

    public static Shake Duplicate(Shake source)
    {
        Shake newShake = new Shake();
        Copy(newShake, source);
        return newShake;
    }
}
