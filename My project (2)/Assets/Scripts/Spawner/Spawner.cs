using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner Instance { get; private set; }

    [Header("Prefabs de enemigos")]
    [SerializeField] private List<GameObject> enemyPrefabs; 

    [Header("Spawn points por tipo de enemigo")]
    [SerializeField] private List<Transform> spawnPointsEnemy0 = new List<Transform>();
    [SerializeField] private List<Transform> spawnPointsEnemy1 = new List<Transform>();
    [SerializeField] private List<Transform> spawnPointsEnemy2 = new List<Transform>();
    [SerializeField] private List<Transform> spawnPointsEnemy3 = new List<Transform>();

    [SerializeField] private float spawnInterval = 5f;

    public event Action<GameObject> OnEnemySpawned;

    private Func<int, int> fibonacciCount = level => Fibonacci(level);

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        int level = 1;
        while (true)
        {
            int enemiesToSpawn = fibonacciCount(level);

            SpawnEnemiesOfType(0, enemiesToSpawn, spawnPointsEnemy0);
            SpawnEnemiesOfType(1, enemiesToSpawn, spawnPointsEnemy1);
            SpawnEnemiesOfType(2, enemiesToSpawn, spawnPointsEnemy2);
            SpawnEnemiesOfType(3, enemiesToSpawn, spawnPointsEnemy3);

            level++;
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnEnemiesOfType(int enemyIndex, int count, List<Transform> spawnPoints)
    {
        if (enemyIndex >= enemyPrefabs.Count || spawnPoints.Count == 0)
            return;

        for (int i = 0; i < count; i++)
        {
            GameStats.Instance.IncreaseLevel();
            Transform spawnPoint = spawnPoints[i % spawnPoints.Count];
            GameObject enemy = Instantiate(enemyPrefabs[enemyIndex], spawnPoint.position, Quaternion.identity);
            OnEnemySpawned?.Invoke(enemy);
        }
    }

    private static int Fibonacci(int n)
    {
        if (n <= 0) return 0;
        if (n == 1) return 1;
        int a = 0, b = 1, c = 1;
        for (int i = 2; i <= n; i++)
        {
            c = a + b;
            a = b;
            b = c;
        }
        return c;
    }
}
