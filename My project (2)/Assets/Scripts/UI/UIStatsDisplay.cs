using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private TMP_Text killText;
    [SerializeField] private TMP_Text levelText;

    private void OnEnable()
    {
        GameStats.OnTimeUpdated += UpdateTime;
        GameStats.OnKillsUpdated += UpdateKills;
        GameStats.OnLevelUpdated += UpdateLevel;
    }

    private void OnDisable()
    {
        GameStats.OnTimeUpdated -= UpdateTime;
        GameStats.OnKillsUpdated -= UpdateKills;
        GameStats.OnLevelUpdated -= UpdateLevel;
    }

    private void UpdateTime(float time)
    {
        timeText.text = $"Tiempo: {time:F1}s";
    }

    private void UpdateKills(int kills)
    {
        killText.text = $"Kills: {kills}";
    }

    private void UpdateLevel(int level)
    {
        levelText.text = $"Nivel: {level/4}";
    }
}
