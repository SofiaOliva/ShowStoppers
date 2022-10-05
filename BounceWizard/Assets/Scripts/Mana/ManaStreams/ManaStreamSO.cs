using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "ManaStream", menuName = "SO/ManaStreamSO")]
public class ManaStreamSO : ScriptableObject
{
    public int maxMana = 3;
    public float mana = 0f;
    [Tooltip("How long it takes to generate 1 mana")]
    public float manaTime = 1f;
    public float overcharge = 1f;
    public float overchargeTime = 1f;

    public event Action Explode;
    public event Action<float> ManaChange;
    public event Action<float> OverchargeChange;

    private float Mana
    {
        get
        {
            return mana;
        }
        set
        {
            float startMana = mana;
            mana = Mathf.Clamp(value, 0f, maxMana);
            if (mana != startMana)
            {
                ManaChange?.Invoke(mana);
            }
        }
    }

    private float Overcharge
    {
        get
        {
            return overcharge;
        }
        set
        {
            overcharge = value;
            OverchargeChange?.Invoke(value);
        }
    }

    void Start()
    {
        Reset();
    }

    public void Reset()
    {
        Mana = 0f;
        Overcharge = 0f;
        ManaChange?.Invoke(Mana);
        OverchargeChange?.Invoke(Overcharge);
    }

    private void OnValidate()
    {
        ManaChange?.Invoke(Mana);
        OverchargeChange?.Invoke(Overcharge);
    }

    public void Fill(float time)
    {
        float manaFillAmount = time / manaTime;
        float extraMana = Mathf.Max(0f, mana+manaFillAmount - maxMana);
        Overcharge += (extraMana / manaFillAmount)*time / overchargeTime;
        //Overcharge += Mathf.Min(0f, time - (maxMana - mana))/overchargeTime;
        if(overcharge >= 1f)
        {
            DoExplode();
        }
        Mana += manaFillAmount;
    }

    public bool TryCast()
    {
        if(Mana >= 1f)
        {
            Cast();
            return true;
        }
        return false;
    }

    void Cast()
    {
        Mana -= 1f;
        Overcharge = 0f;
    }

    void DoExplode()
    {
        Explode?.Invoke();
        Overcharge = 0f;
        Mana = 0f;
    }
}
