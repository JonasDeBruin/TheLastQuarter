using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamemanagerMainGame : MonoBehaviour
{

    public static Transform playerTransform;
    public GameObject player;

    public static Transform enemyTransform;
    public GameObject enemy;

    public static int ticketCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (playerTransform != null && enemyTransform != null)
        {
            player.transform.position = playerTransform.position;
            enemy.transform.position = enemyTransform.position;
        }
    }

    public void safePosition()
    {
        playerTransform = player.transform;
        enemyTransform = enemy.transform;
    }
}
