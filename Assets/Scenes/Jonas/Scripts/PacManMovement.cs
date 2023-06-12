using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PacManMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;


    //1 = up, 2 = down, 3 = left, 4 = right
    private int direction = 1;

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            direction = 1;
                transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        }

        if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)))
        {
            direction = 2;
                transform.rotation = Quaternion.Euler(0f, 0f, 270);
        }
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)))
        {
            direction = 3;
                transform.rotation = Quaternion.Euler(0f, 0f, 180f);
        }
        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)))
        {
            direction = 4;
                transform.rotation = Quaternion.Euler(0f, 0f, 0);
        }

        switch (direction)
        {
            case 1:
                transform.position += speed * Time.deltaTime * Vector3.up;
                break;
            case 2:
                transform.position += speed * Time.deltaTime * Vector3.down;

                break;
            case 3:
                transform.position += speed * Time.deltaTime * Vector3.left;
                break;
            case 4:
                transform.position += speed * Time.deltaTime * Vector3.right;
                break;
            default: break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            Debug.Log("Hit collion");
        //check for collision with map tag
        if (collision.gameObject.CompareTag("Map"))
        {
            transform.position = new Vector2(0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Teleporter"))
        {
            if (collision.gameObject.GetComponent<Teleporter>().isTeleporterA)
            {
                StartCoroutine(collision.gameObject.GetComponent<Teleporter>().WaitCollision());
                transform.position = new Vector3(-4f, 1.1f);
                

            }
            else
            {
                StartCoroutine(collision.gameObject.GetComponent<Teleporter>().WaitCollision());
                transform.position = new Vector2(4f, 1.1f);
            }
        }
    }
}