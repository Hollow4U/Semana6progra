using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private InGameHUD inGameHUD;
    [SerializeField] private GameOverUI gameOverPanel;

    private void Awake()
    {
        if (Instance != null) { Destroy(gameObject); return; }
        Instance = this;
    }

    public void UpdateTime(float time) => inGameHUD?.UpdateTime(time);
    public void UpdateKills(int kills) => inGameHUD?.UpdateKills(kills);
    public void UpdateLevel(int level) => inGameHUD?.UpdateLevel(level);

    public void ShowGameOver(float time, int kills, int level)
    {
        gameOverPanel?.SetStats(time, kills, level);
        gameOverPanel?.Show();
    }

    public void HideGameOver() => gameOverPanel?.Hide();
}