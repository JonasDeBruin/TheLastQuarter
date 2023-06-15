using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Wave_Spawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;
    public int[] EnemyCountPerWave;

    private float countdown = 2f;
    private int waveIndex = 0;
    private bool gameStarted = false;

    private void Update()
    {
        
        if (!gameStarted)
        {
            if (countdown <= 0f)
            {
                gameStarted = true;
                StartCoroutine(SpawnWave());
            }
            countdown -= Time.deltaTime;
            return;
        }
        if (gameStarted && CheckIfAllEnemiesDead() && !TDGameManager.gameEnded)
        {
            StartCoroutine(SpawnWave());
        }
    }

    public bool CheckIfAllEnemiesDead()
    {
       return GameObject.FindGameObjectsWithTag("Enemy").Length == 0;
    }

    IEnumerator SpawnWave()
    {
        TDGameManager.roundsSurvived++;
        for (int i = 0; i < EnemyCountPerWave[waveIndex]; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        
        waveIndex++;
        
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }


}
