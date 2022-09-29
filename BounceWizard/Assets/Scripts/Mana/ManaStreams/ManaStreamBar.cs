using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
public class ManaStreamBar : MonoBehaviour
{
    [SerializeField] ManaStreamSO stream;
    [SerializeField] Image fillContinous;
    [SerializeField] Image fillDiscrete;
    [SerializeField] Image fillOvercharge;

    private void OnEnable()
    {
        if (!stream) return;
        stream.ManaChange += OnManaChange;
        stream.OverchargeChange += OnOverchargeChange;
    }
    private void OnDisable()
    {
        if (!stream) return;
        stream.ManaChange -= OnManaChange;
        stream.OverchargeChange -= OnOverchargeChange;
    }

    void OnManaChange(float mana)
    {
        fillContinous.fillAmount = mana / stream.maxMana;
        fillDiscrete.fillAmount = Mathf.Floor(mana) / stream.maxMana;
        
    }

    void OnOverchargeChange(float v)
    {
        fillOvercharge.fillAmount = v;
    }


}
