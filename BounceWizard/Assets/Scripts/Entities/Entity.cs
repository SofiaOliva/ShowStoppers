using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Entity : MonoBehaviour
{
    public int maxHealth = 3;
    public int health;

    public event Action<int> HealthChange;

    private void Start()
    {
        SetHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        if (health <= 0) return;
        ChangeHealth(-damage);
        if (health <= 0) Die();
    }

    private void ChangeHealth(int change)
    {
        SetHealth(health + change);
    }

    private void SetHealth(int newHealth)
    {
        int startHealth = health;
        health = Mathf.Clamp(newHealth, 0, maxHealth);
        if (startHealth != health)
        {
            HealthChange?.Invoke(health);
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
