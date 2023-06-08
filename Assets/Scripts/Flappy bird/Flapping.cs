using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flapping : MonoBehaviour
{
    public float jumpForce = 5f;

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpForce;
        }
    }
}
