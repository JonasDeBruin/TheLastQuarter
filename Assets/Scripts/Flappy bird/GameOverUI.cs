using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    private Text gameOverText;

    private void Awake()
    {
        gameOverText = GetComponent<Text>();
    }

    private void Start()
    {
        gameOverText.enabled = false;
    }

    public void ShowGameOverText()
    {
        gameOverText.enabled = true;
        gameOverText.text = "Game Over\nPress Space to Start Over";
    }
}
