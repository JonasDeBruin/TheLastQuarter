using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private bool gameOver = false;
    private bool isPaused = false;
    private GameOverUI gameOverUI;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        gameOverUI = FindObjectOfType<GameOverUI>();
    }

    private void Update()
    {
        if (gameOver && Input.GetButtonDown("Jump"))
        {
            // Restart the game
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (gameOver && Input.GetButtonDown("Cancel"))
        {
            // Quit the game
            Application.Quit();
        }

        if (Input.GetButtonDown("Jump") && isPaused)
        {
            // Resume the game
            Time.timeScale = 1f;
            isPaused = false;
        }
    }

    public void GameOver()
    {
        gameOver = true;
        Debug.Log("Game Over");

        // Pause the game
        Time.timeScale = 0f;
        isPaused = true;

        // Show game over text
        gameOverUI.ShowGameOverText();
    }
}

