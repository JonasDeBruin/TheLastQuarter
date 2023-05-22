using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Platformer_Movement : MonoBehaviour
{

    public float speed;
    public Rigidbody2D rb2d;
    public float jumpForce;

    public Vector3 boxSize;

    public float maxd;

    public LayerMask layerMask;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        rb2d.velocity = new Vector2(moveHorizontal * speed, rb2d.velocity.y);

        
        
        if (Input.GetKeyDown(KeyCode.Space) && Groundcheck())
        {
            Debug.Log("Jump");
            rb2d.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position - transform.up * maxd, boxSize);
    }

    private bool Groundcheck()
    {
        if (Physics2D.BoxCast(transform.position,boxSize,0,-transform.up,maxd,layerMask))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
