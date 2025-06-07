using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverUI : UIPanelBase
{
    [SerializeField] private GameObject panel;
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private TMP_Text killText;
    [SerializeField] private TMP_Text levelText;

    private void OnEnable()
    {
        PlayerHealth.OnPlayerDeath += ShowGameOverScreen;
    }

    private void OnDisable()
    {
        PlayerHealth.OnPlayerDeath -= ShowGameOverScreen;
    }

    public override void Show()
    {
        panel.SetActive(true);
    }

    public override void Hide()
    {
        panel.SetActive(false);
    }

    public void SetStats(float time, int kills, int level)
    {
        timeText.text = $"Tiempo: {time:F1}s";
        killText.text = $"Kills: {kills}";
        levelText.text = $"Nivel: {level/4}";
    }

    private void ShowGameOverScreen()
    {
        SetStats(GameStats.Instance.SurvivalTime, GameStats.Instance.Kills, GameStats.Instance.Level);
        Show();
    }
}