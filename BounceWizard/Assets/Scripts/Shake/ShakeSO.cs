using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Shake", menuName = "SO/ShakeSO")]
public class ShakeSO : ScriptableObject
{
    public Shake shake;
    public EventSO_Shake shakeEvent;

    public void DoShake()
    {
        shakeEvent?.Trigger(Shake.Duplicate(shake));
    }
}
