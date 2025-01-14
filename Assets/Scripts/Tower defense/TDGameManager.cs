using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TDGameManager : MonoBehaviour
{
    public static bool gameEnded = false;
    public static int roundsSurvived = 0;
    public GameObject winUI;

    private void Update()
    {
        if (gameEnded) return;
        if (Player_Stats.Lives <= 0)
        {
            EndGame();
        }
        if (roundsSurvived >= 5 && CheckIfAllEnemiesDead())
        {
            WonGame();
        }
    }

    private void EndGame()
    {
        gameEnded = true;
        SceneManager.LoadScene("LosingScreenMG");
        Debug.Log("Game Over!");
    }

    public bool CheckIfAllEnemiesDead()
    {
        return GameObject.FindGameObjectsWithTag("Enemy").Length == 0;
    }

    private void WonGame()
    {
        SceneManager.LoadScene("WinScreenMG");
    }
}
