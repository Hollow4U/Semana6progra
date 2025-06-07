using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static event Action OnEnemyKilled;
    public static int EnemiesKilled { get; private set; } = 0;

    private void OnEnable() => OnEnemyKilled += IncrementKillCount;
    private void OnDisable() => OnEnemyKilled -= IncrementKillCount;

    private void IncrementKillCount()
    {
        EnemiesKilled++;
        Debug.Log($"Enemigos eliminados: {EnemiesKilled}");
    }

    public static void NotifyEnemyKilled()
    {
        OnEnemyKilled?.Invoke();
    }
}
