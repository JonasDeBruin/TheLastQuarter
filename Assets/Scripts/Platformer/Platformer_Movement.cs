using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Platformer_Movement : MonoBehaviour
{
    public float Move;
    public float speed;
    public Rigidbody2D rb;
    public float jumpForce;
    private bool isGrounded;
    private bool isJumping;
    private bool doubleJump;

    private bool facingRight = true;

    public SpriteRenderer sprite;


    public Animation anim;
    private Animations anims;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        anim = GetComponentInChildren<Animation>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
        }

        switch (anims)
        {
            case Animations.walk:
                anim.Play("WalkAnim");
                break;
            case Animations.idle:
                anim.Play("Player_Idle");
                break;
            case Animations.jump:
                anim.Play("JumpAnim");
                break;
            case Animations.fall:
                anim.Play("FallAnim");
                break;
            default:
                break;
        }
    }

    private void FixedUpdate()
    {
        float Move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(Move * speed, rb.velocity.y);



        if (Move > 0)
        {
            sprite.flipX = false;
        }
        else if (Move < 0)
        {
            sprite.flipX = true;
        }

        if (isJumping && (isGrounded || doubleJump))
        {
            if (!isGrounded)
            {
                doubleJump = false;
            }
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
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

    private void SetAnimationState(float Move)
    {
        if (Move == 0 && isGrounded) { anims = Animations.idle; return; }
        else
        if (Move != 0 && isGrounded) { anims = Animations.walk; return; }

        if (rb.velocity.y > 0 && !isGrounded) { anims = Animations.jump; return; }
        else
        if (rb.velocity.y < 0 && !isGrounded) { anims = Animations.fall; return; }
    }


    public enum Animations
    {
        walk,
        idle,
        jump,
        fall
    }
}
