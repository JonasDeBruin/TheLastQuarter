using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float EnemySpeed;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(transform.right * -1 * EnemySpeed * Time.deltaTime);


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Ouch");
            Destroy(gameObject);
        }
    }
}
