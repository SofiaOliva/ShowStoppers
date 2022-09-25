using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EntityUI : MonoBehaviour
{
    public Entity entity;
    public TMP_Text healthText;
    private void OnEnable()
    {
        entity.HealthChange += OnHealthChange;
    }

    private void OnDisable()
    {
        entity.HealthChange -= OnHealthChange;
    }

    private void OnHealthChange(int newHealth)
    {
        healthText.text = ""+newHealth;
    }
}
