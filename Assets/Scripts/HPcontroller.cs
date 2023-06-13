using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HPcontroller : MonoBehaviour
{
    public int PlayerHP = 3;
    [SerializeReference] private Image [] hearts;

    // Start is called before the first frame update
    void Start()
    {
        UpdateHealth();
    }

    private void Update()
    {
        if (PlayerHP == 0)
        {
            Die();
        }
    }

    // Update is called once per frame

    public void UpdateHealth()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < PlayerHP)
            {
                hearts[i].color = Color.white;
            }
            else
            {
                hearts[i].color = Color.black;
            }
        }
    }

    public void Die()
    {
        SceneManager.LoadScene("SpaceGameMM");
    }
}

