using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Platformer_Movement : MonoBehaviour
{

    public float speed;
    public Rigidbody2D rb2d;
    public float jumpForce;
    private bool isGrounded;
    private bool isJumping;
    private bool doubleJump;

    private bool facingRight = true;

    public SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
        }
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        rb2d.velocity = new Vector2(moveHorizontal * speed, rb2d.velocity.y);

        if (moveHorizontal > 0)
        {
            sprite.flipX = false;
        }
        else if (moveHorizontal < 0)
        {
            sprite.flipX = true;
        }

        if (isJumping && (isGrounded || doubleJump))
        {
            Debug.Log("Jump");
            if (!isGrounded)
            {
                doubleJump = false;
            }
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0f);
            rb2d.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            isJumping = false;
            
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            doubleJump = true;
        }
    }
}
