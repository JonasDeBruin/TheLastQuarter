using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacManMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    //1 = up, 2 = down, 3 = left, 4 = right
    private int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && !Physics.Raycast(transform.position, Vector3.up, 1f))
        {
            direction = 1;
        }

        if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && !Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            direction = 2;
        }
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && !Physics.Raycast(transform.position, Vector3.left, 1f))
        {
            direction = 3;
        }
        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && !Physics.Raycast(transform.position, Vector3.right, 1f))
        {
            direction = 4;
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
}