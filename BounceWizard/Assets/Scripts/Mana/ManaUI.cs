using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class ManaUI : MonoBehaviour
{
    public ManaStreamSO manaStream;

    public TMP_Text[] manaTexts;

    private void OnEnable()
    {
        manaStream.ManaChange += OnManaChange;
    }

    private void OnDisable()
    {
        manaStream.ManaChange -= OnManaChange;
    }

    private void OnManaChange(float newMana)
    {
        manaTexts[0].text = ""+System.Math.Floor(newMana);
    }
}
