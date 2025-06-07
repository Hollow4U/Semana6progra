using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InGameHUD : MonoBehaviour, IStatsDisplay
{
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private TMP_Text killText;
    [SerializeField] private TMP_Text levelText;

    public void UpdateTime(float time) => timeText.text = $"Tiempo: {time:F1}s";
    public void UpdateKills(int kills) => killText.text = $"Kills: {kills}";
    public void UpdateLevel(int level) => levelText.text = $"Nivel: {level}";
}
