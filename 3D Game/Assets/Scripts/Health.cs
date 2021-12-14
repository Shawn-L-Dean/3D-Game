using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float totalHealth;

    public void Awake()
    {
        GameManager.health = totalHealth;
        totalHealth = 200;
    }

    public void TakeDamage(float damage)
    {
        totalHealth -= damage;
        GameManager.health = totalHealth;

        if (totalHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        gameObject.SetActive(false);
    }
}
