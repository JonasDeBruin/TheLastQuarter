using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeController : MonoBehaviour
{
    [SerializeField] bool canMoveLeft = false;
    [SerializeField] bool canMoveRight = false;
    [SerializeField] bool canMoveUp = false;
    [SerializeField] bool canMoveDown = false;

    public GameObject leftNode;
    public GameObject rightNode;
    public GameObject upNode;
    public GameObject downNode;

    private void CheckRaycast(ref bool canMove, ref GameObject node, Vector2 direction)
    {
        RaycastHit2D[] hits;
        hits = Physics2D.RaycastAll(transform.position, direction);

        for (int i = 0; i < hits.Length; i++)
        {
            float distance;

            if (direction == -Vector2.up || direction == Vector2.up)
            {
                distance = Mathf.Abs(hits[i].point.y - transform.position.y);
            }
            else if (direction == Vector2.right || direction == Vector2.left)
            {
                distance = Mathf.Abs(hits[i].point.x - transform.position.x);
            }
            else
            {
                distance = 0f;
            }

            if (distance < 0.4f)
            {
                canMove = true;
                node = hits[i].collider.gameObject;
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        CheckRaycast(ref canMoveDown, ref downNode, -Vector2.up);
        CheckRaycast(ref canMoveUp, ref upNode, Vector2.up);
        CheckRaycast(ref canMoveRight, ref rightNode, Vector2.right);
        CheckRaycast(ref canMoveLeft, ref leftNode, Vector2.left);
    }
    
    public GameObject GetNodeFromDirection(string direction)
    {
        if (direction == "left" && canMoveLeft)
        {
            return leftNode;
        }
        else if (direction == "right" && canMoveRight)
        {
            return rightNode;
        }
        else if (direction == "up" && canMoveUp)
        {
            return upNode;
        }
        else if (direction == "down" && canMoveDown)
        {
            return downNode;
        }
        else
        {
            return null;
        }
    }
}