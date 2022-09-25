using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public int maxHealth = 3;
    public int health;

    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (health <= 0) return;
        health = Mathf.Max(0, health - damage);
        if (health <= 0) Die();
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
