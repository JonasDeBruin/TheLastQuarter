using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed = 3f;
    public float strarting;

    public float dirX = 1f;
    bool isAlive = true;

    public Animator anim;
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        anim.Play("Enemy_Idle");
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            transform.Translate(transform.right * dirX * speed * Time.deltaTime);

            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right * dirX, 0.6f);

            Debug.DrawRay(transform.position, transform.right * 0.6f * dirX, Color.blue);

            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("wall"))
                {
                    dirX *= -1f;
                }
            }

        }
        Debug.Log(dirX);

        if (dirX == 1)
        {
            spriteRenderer.flipX = false;
        }
        else if (dirX == -1)
        {
            spriteRenderer.flipX = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            die();
        }
    }


    void die()
    {
        isAlive = false;
        anim.Play("Enemy_die");
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().gravityScale = 0;
        Destroy(gameObject, 1f);
    }
}
