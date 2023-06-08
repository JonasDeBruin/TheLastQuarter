using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PipeController : MonoBehaviour
{
    public string finishSceneName; // The name of the scene to load when the finish object is hit

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (gameObject.CompareTag("FlappyFinish"))
            {
                SceneManager.LoadScene(finishSceneName);
            }
            else
            {
                GameManager.Instance.GameOver();
            }
        }
    }
}
