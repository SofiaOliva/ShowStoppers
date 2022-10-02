using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Entity : MonoBehaviour
{
    public int maxHealth = 3;
    //public int health;
    [SerializeField] private FloatReference Health;
    [SerializeField] ShakeSO hitShake;
    [SerializeField] SoundSO dieSound;

    public bool blessed = false;

    public float health
    {
        get
        {
            return Health.Value;
        }
        set
        {
            Health.Value = value;
        }
    }

    public FloatReference GetHealthReference()
    {
        return Health;
    }

    private void Start()
    {
        SetHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        if (health < 1) return;
        ChangeHealth(-damage);
        hitShake.DoShake();
        if (health < 1) Die();
    }

    public void ChangeHealth(float change)
    {
        SetHealth(health + change);
    }

    private void SetHealth(float newHealth)
    {
        health = Mathf.Clamp(newHealth, 0f, maxHealth);
    }

    public void Die()
    {
        dieSound.Play(transform.position);
        Destroy(gameObject);
    }
}
