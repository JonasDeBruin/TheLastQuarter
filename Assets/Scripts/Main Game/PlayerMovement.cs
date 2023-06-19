using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool on = true;

    public float gravityScale;
    public float JumpHeight;

    [Header("Speed Settings")]
    public float defaultSpeed;
    public float runMultiplier, sneakMultiplier;

    [Header("Input Keys")]
    public KeyCode sneakKey;
    public KeyCode runKey, jumpKey;


    [SerializeField]
    bool isGrounded;

    [HideInInspector]
    public bool isRunning, canRun = true;
    [SerializeField]
    Animator anim;
    CharacterController controller;
    Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (on)
        {
            //GroundCheck
            isGrounded = Physics.Raycast(transform.position, Vector3.down, 2.1f);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            float x = Input.GetAxis("Horizontal") * 0.8f; //Make speed 80% sideways;
            float z = Input.GetAxis("Vertical");

            //Check if running for stamina
            if (Input.GetKey(runKey)) { isRunning = true; }
            else { isRunning = false; }

            //If walking backwards makes speed 50%
            if (z < 0)
            {
                z *= 0.5f;
            }

            if (z + Mathf.Abs(x) > 1)
            {
                z *= 0.75f;
                x *= 0.5f;
            }

            //Play animations
            if (GetComponent<PlayerCameraMove>().animate)
            {
                animations(Mathf.Abs(x) + Mathf.Abs(z));
            }

            //Move player
            Vector3 move = transform.right * x + transform.forward * z;
            controller.Move(move * currentSpeed() * Time.deltaTime);

            //Jump
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(JumpHeight * -2 * gravityScale);
            }

            //Gravity
            velocity.y += gravityScale * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
    }

    void animations(float move)
    {
        //Run animation
        if(Input.GetKey(runKey) && canRun) {anim.SetBool("Running", true);}
        else {
            anim.SetBool("Running", false);

            if (Input.GetKey(sneakKey))
            {
                if (controller.height > 1)
                {
                    controller.height -= Time.deltaTime * 5;
                }
            }
            else
            {
                if(controller.height < 2)
                {
                    controller.height += Time.deltaTime * 5;
                }
                //Walking animation
                if (move > 0) { anim.SetBool("Walking", true); }
                else { anim.SetBool("Walking", false); }
            }
        }
    }

    float currentSpeed()
    {
        //Get speed
        if (Input.GetKey(runKey) && canRun)
        {
            return defaultSpeed * runMultiplier;
        }
        else if (Input.GetKey(sneakKey))
        {
            return defaultSpeed * sneakMultiplier;
        }
        return defaultSpeed;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log(hit.gameObject.name);
    }
}
