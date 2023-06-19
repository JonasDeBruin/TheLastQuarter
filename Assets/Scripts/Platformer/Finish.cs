using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{

    public GameObject player;
    public GameObject MonsterWall;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            MonsterWall.GetComponent<MonsterWall>().stop();
            player.GetComponentInChildren<Platformer_Movement>().Resetvelocity();
            player.GetComponentInChildren<Animator>().Play("Player_Finish");
            player.GetComponent<Platformer_Movement>().enabled = false;
            StartCoroutine(DelaySceneLoad());

        }
    }

    IEnumerator DelaySceneLoad()
    {
        yield return new WaitForSeconds(1f); // Wait 1 seconds
        SceneManager.LoadScene("WinScreenMG");
    }
}
