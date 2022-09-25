using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManaUI : MonoBehaviour
{
    ManaPool manaPool;

    public TMP_Text[] manaTexts;

    public void Awake()
    {
        manaPool = FindObjectOfType<ManaPool>();
    }

    private void OnEnable()
    {
        manaPool.manaStreams[0].ManaChange += OnFireManaChange;
    }

    private void OnDisable()
    {
        manaPool.manaStreams[0].ManaChange -= OnFireManaChange;
    }

    private void OnFireManaChange(float newMana)
    {
        manaTexts[0].text = System.Math.Floor(newMana)+"/"+ manaPool.manaStreams[0].maxMana;
    }
}
