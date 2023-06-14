using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;

    public float Spawnrate = 1f;
    private bool canSpawn = true;
    // Start is called before the first frame update

    private void Start()
    {
        StartCoroutine(EnemySpawn());
    }
    public IEnumerator EnemySpawn()
    {
        WaitForSeconds Wait= new WaitForSeconds(Spawnrate);

        while (canSpawn)
        {
            yield return Wait;
            int randomEnemy = Random.Range(0, enemyPrefabs.Length);
            int randomSP = Random.Range(0, spawnPoints.Length);
            Instantiate(enemyPrefabs[randomEnemy], spawnPoints[randomSP].position, transform.rotation);
        }
    }
}
