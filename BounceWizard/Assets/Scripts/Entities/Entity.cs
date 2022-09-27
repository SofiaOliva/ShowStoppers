using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Entity : MonoBehaviour
{
    public int maxHealth = 3;
    public int health;

    public ShakeSO hurtScreenShake;

    public event Action<int> HealthChange;

    private void Start()
    {
        SetHealth(maxHealth);
    }

    public virtual void TakeDamage(int damage)
    {
        if (health <= 0) return;
        hurtScreenShake?.DoShake();
        ChangeHealth(-damage);
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
        if(health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
