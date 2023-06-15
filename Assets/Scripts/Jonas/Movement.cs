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

    [SerializeField] private GameObject rightTeleporter;
    [SerializeField] private GameObject rightTeleportTo;
    [SerializeField] private GameObject leftTeleporter;
    [SerializeField] private GameObject leftTeleportTo;

    // Update is called once per frame
    void Update()
    {
        NodeController currentNodeController = currentNode.GetComponent<NodeController>();

        if (currentNode == rightTeleporter)
        {
            transform.position = leftTeleporter.transform.position;
            currentNode = leftTeleportTo;
        }
        else if (currentNode == leftTeleporter)
        {
            transform.position = rightTeleporter.transform.position;
            currentNode = rightTeleportTo;
        }


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

    public string GetDirection()
    {
        return direction;
    }
}