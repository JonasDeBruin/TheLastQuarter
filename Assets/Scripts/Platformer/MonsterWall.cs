using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterWall : MonoBehaviour
{
    public Rigidbody2D rb;

    public float speed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
            collision.gameObject.GetComponent<Player>().die();
        }
    }

    public void stop()
    {
        speed = 0f;
    }
}
