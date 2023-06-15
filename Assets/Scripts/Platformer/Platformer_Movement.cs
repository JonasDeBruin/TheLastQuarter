using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;

public class Platformer_Movement : MonoBehaviour
{
    public float WalkSpeed = 10;
    public float JumpForce = 5;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float maxJumpTime = .3f;
    public int airJumps = 2;
    private int numberofAirJumps = 0;


    private Animator anim;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private CapsuleCollider2D capsuleCollider;
    public Animations anims;

    [SerializeField]
    private PhysicsMaterial2D playerAir;

    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private bool isGrounded;
    private bool endJump;

    [HideInInspector]
    public bool inLaunchpad;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {


        Jump();

        //Animation SwitchCase
        AnimationSwitchCase();

        //Realistic Jump (Make jump shorter if holding "Jump" down shorter)
        if (!inLaunchpad)
            Fallmultiplier();


        if (!isGrounded)
        {
            capsuleCollider.sharedMaterial = playerAir;
        }
        else { capsuleCollider.sharedMaterial = null; }
       

    }

    private void Fallmultiplier()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump") || endJump)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    private Animations previousAnim;

    private void AnimationSwitchCase()
    {
    if (anims == previousAnim) return;

        switch (anims)
        {

            case Animations.idle:
                anim.Play("Player_Idle");
                break;
            case Animations.jump:
                anim.Play("Player_Jump");
                break;
            case Animations.walk:
                anim.Play("Player_Run");
                break;
            case Animations.fall:
                anim.Play("Player_Fall");
                break;
            default:
                break;
        }
        previousAnim = anims;
    }

    private void Jump()
    {
        //GroundCheck
        isGrounded = isGroundedCheck();


        if (Input.GetButtonDown("Jump") && isGrounded || Input.GetButtonDown("Jump") && !isGrounded && numberofAirJumps < airJumps)
        {
            numberofAirJumps++;
            endJump = false;
            //CancelInvoke("JumpEnd");
            Invoke("JumpEnd", maxJumpTime);
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
        else if (isGrounded) { endJump = false; }

        if (isGrounded)
        {
            numberofAirJumps = 0;
        }
    }

    private void JumpEnd()
    {
        endJump = true;
    }

    private bool isGroundedCheck()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }
    private void FixedUpdate()
    {
        //Horizontal Input
        var Move = Input.GetAxis("Horizontal");

        //Movement
        Movement(Move);
        //flip sprite
        if (Move > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (Move < 0)
        {
            spriteRenderer.flipX = true;
        }
        //Player Facing Direction
        //SetPlayerDirection(Move);

        //Set enum state to the correct animation type
        SetAnimationState(Move);
    }
    private void Movement(float Move)
    {
        transform.position += new Vector3(Move, 0, 0) * Time.deltaTime * WalkSpeed;
    }

    private void SetPlayerDirection(float Move)
    {
        if (Move > 0 && spriteRenderer.flipX) { spriteRenderer.flipX = false; }
        if (Move < 0 && !spriteRenderer.flipX) { spriteRenderer.flipX = true; }
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

    public void Resetvelocity()
    {
        rb.velocity = new Vector2(0f, 0f);
    }

}

    public enum Animations
    {
        walk,
        idle,
        jump,
        fall,
    }



