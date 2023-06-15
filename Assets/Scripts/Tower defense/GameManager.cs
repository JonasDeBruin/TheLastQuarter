using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
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
        if (roundsSurvived > 5)
        {
            WonGame();
        }
    }

    private void EndGame()
    {
        gameEnded = true;
        Debug.Log("Game Over!");
    }

    private void WonGame()
    {
        winUI.SetActive(true);
    }
}
