using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    [SerializeField] private GameObject currentNode;
    [SerializeField] private float speed = 5f;

    
    private string direction = "";
    private string lastMovingDirection = "";
    // Update is called once per frame
    void Update()
    {
        NodeController currentNodeController = currentNode.GetComponent<NodeController>();

        transform.position = Vector2.MoveTowards(transform.position, currentNode.transform.position, speed * Time.deltaTime);

        bool reverseDirection = false;
        if(
            (direction == "left" && lastMovingDirection == "right" ) ||
            (direction == "right" && lastMovingDirection == "left" ) ||
            (direction == "up" && lastMovingDirection == "down"    ) ||
            (direction == "down" && lastMovingDirection == "up"    )
            )
        {
            reverseDirection = true;
        }
        
        //Check if we in the middle of the node
        if ((transform.position.x == currentNode.transform.position.x && transform.position.y == currentNode.transform.position.y) || reverseDirection)
        {
            
            GameObject newNode = currentNodeController.GetNodeFromDirection(direction);

            if (newNode != null)
            {
                currentNode = newNode;
                lastMovingDirection = direction;
            }
            else
            {
                direction = lastMovingDirection;
                newNode = currentNodeController.GetNodeFromDirection(direction);
                if (newNode != null)
                {
                    currentNode = newNode;
                }
            }
        }
    }

    public void SetDirection(string newDirection)
    {
        direction = newDirection;
    }

    //Teleporter
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