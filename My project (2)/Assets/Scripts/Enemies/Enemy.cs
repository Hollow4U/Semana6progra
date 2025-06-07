using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamage
{
    public float maxHealth = 100f;
    public float moveSpeed = 3f;
    [SerializeField] private float currentHealth;

    protected int damage = 1;

    private Transform player;

    [Header("Strategy")]
    [SerializeField] private MonoBehaviour strategyComponent; 
    private IEnemyStrategy strategy;

    void Start()
    {
        currentHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player")?.transform;

        strategy = strategyComponent as IEnemyStrategy;
        if (strategy == null)
        {
            Debug.LogError("La estrategia no implementa IEnemyStrategy");
        }
    }

    void Update()
    {
        strategy?.Execute(transform, player, moveSpeed);
    }

    public void SetStrategy(IEnemyStrategy newStrategy)
    {
        strategy = newStrategy;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        EnemyManager.NotifyEnemyKilled();
        Destroy(gameObject);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        IDamage damageable = other.GetComponent<IDamage>();
        if (damageable != null)
        {
            damageable.TakeDamage(damage);
        }
    }
}
