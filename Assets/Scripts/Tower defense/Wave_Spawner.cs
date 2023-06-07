using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using TMPro;

public class Wave_Spawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;
    public TMP_Text waveCountDownText;

    private float countdown = 2f;
    private int waveIndex = 0;

    private void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;

        waveCountDownText.text = Mathf.Floor(countdown + 1).ToString();
    }

    IEnumerator SpawnWave()
    {
        
        for (int i = 0; i <= waveIndex; i++)
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
