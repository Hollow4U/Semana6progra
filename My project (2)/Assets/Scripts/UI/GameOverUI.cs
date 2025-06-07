using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    void OnEnable()
    {
        PlayerHealth.OnPlayerDeath += ShowGameOverScreen;
    }

    void OnDisable()
    {
        PlayerHealth.OnPlayerDeath -= ShowGameOverScreen;
    }

    private void ShowGameOverScreen()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true); 
        }
    }
}