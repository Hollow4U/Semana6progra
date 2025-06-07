using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamage
{
    public float maxHealth = 100f;
    public float currentHealth;

    public static event Action OnPlayerDeath; 

    void Start()
    {
        currentHealth = maxHealth;
    }


    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        Debug.Log($"Jugador recibió daño: {amount}. Vida actual: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("¡Jugador ha muerto!");
        OnPlayerDeath?.Invoke();
        gameObject.SetActive(false);
    }
}
