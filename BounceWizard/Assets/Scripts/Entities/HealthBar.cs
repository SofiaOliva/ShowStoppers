using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
public class HealthBar : MonoBehaviour
{
    private Entity entity;
    [SerializeField] Image fillImage;


    IntReference healthReference;

    void OnEnable()
    {
        entity = GetComponentInParent<Entity>();
        healthReference = entity.GetHealthReference();
        healthReference.ChangeEvent += OnHealthChange;
    }

    private void OnDisable()
    {
        healthReference.ChangeEvent -= OnHealthChange;
    }

    void OnHealthChange(int health)
    {
        fillImage.fillAmount = (float)health / entity.maxHealth;
    }
}
