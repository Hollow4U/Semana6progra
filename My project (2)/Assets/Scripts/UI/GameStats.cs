using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats : MonoBehaviour
{
    public static GameStats Instance { get; private set; }

    public float SurvivalTime { get; private set; }
    public int Kills { get; private set; }
    public int Level { get; private set; }

    public static event Action<float> OnTimeUpdated;
    public static event Action<int> OnKillsUpdated;
    public static event Action<int> OnLevelUpdated;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        SurvivalTime += Time.deltaTime;
        OnTimeUpdated?.Invoke(SurvivalTime);
    }

    public void AddKill()
    {
        Kills++;
        OnKillsUpdated?.Invoke(Kills);
    }

    public void IncreaseLevel()
    {
        Level++;
        OnLevelUpdated?.Invoke(Level);
    }

    public void ResetStats()
    {
        SurvivalTime = 0;
        Kills = 0;
        Level = 1;

        OnTimeUpdated?.Invoke(SurvivalTime);
        OnKillsUpdated?.Invoke(Kills);
        OnLevelUpdated?.Invoke(Level);
    }
}
