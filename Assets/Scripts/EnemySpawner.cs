using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    // Start is called before the first frame update
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            int randomEnemy = Random.Range(0, enemyPrefabs.Length);
            int randomSP = Random.Range(0, spawnPoints.Length);
            Instantiate(enemyPrefabs[randomEnemy], spawnPoints[randomSP].position, transform.rotation);
        }

        
    }
}
