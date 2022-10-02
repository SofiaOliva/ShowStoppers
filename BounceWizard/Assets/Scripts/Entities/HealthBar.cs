using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
public class HealthBar : MonoBehaviour
{
    private Entity entity;
    [SerializeField] Image imageDiscrete;
    [SerializeField] Image imageContinous;


    FloatReference healthReference;

    void OnEnable()
    {
        entity = GetComponentInParent<Entity>();
        if (!entity) return;
        healthReference = entity.GetHealthReference();
        healthReference.ChangeEvent += OnHealthChange;
    }

    private void OnDisable()
    {
        if (healthReference == null) return;
        healthReference.ChangeEvent -= OnHealthChange;
    }

    void OnHealthChange(float health)
    {
        imageDiscrete.fillAmount = Mathf.Floor(health) / entity.maxHealth;
        imageContinous.fillAmount = health / entity.maxHealth;
    }
}
