using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

   
    public TextMeshProUGUI scoretext;
    public int score;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        scoretext.text = "Score " + score.ToString();
    }

    private void Update()
    {
        if (score == 5000)
        {
            SceneManager.LoadScene("WinScreenMG");
        }
    }

    public void Addscore()
    {
        score += 100;
        scoretext.text = "Score " + score.ToString();
    }
}
