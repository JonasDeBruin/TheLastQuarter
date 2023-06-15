using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class PacManController : MonoBehaviour
{
    Movement movementController;
    private int score = 0;
    [SerializeField] private TMP_Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        movementController = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {

        //input for all dirctions
        if (Input.GetKeyDown(KeyCode.W))
        {
            movementController.SetDirection("up");

        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            movementController.SetDirection("down");
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            movementController.SetDirection("left");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            movementController.SetDirection("right");
        }
        //check in what direction the player is moving
        if (movementController.GetDirection() == "up")
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        }
        else if (movementController.GetDirection() == "down")
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 270);
        }
        else if (movementController.GetDirection() == "left")
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 180f);
        }
        else if (movementController.GetDirection() == "right")
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0);
        }
    }

    private void CheckForWin()
    {
        if (score == 2980)
        {

        }
        //var objects = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == "Node"|| obj.name == "Node(Clone)");
        //return true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Node"))
        {
            GameObject pallet = collision.gameObject.transform.GetChild(0).gameObject;
            if (pallet.activeSelf == true)
            {
                score += 10;
                scoreText.text = "Score:" + score.ToString("00");
            }
            pallet.SetActive(false);

        }

        //if (collision.gameObject.CompareTag("Teleporter"))
        //{
        //    if (collision.gameObject.GetComponent<Teleporter>().isTeleporterA)
        //    {
        //        StartCoroutine(collision.gameObject.GetComponent<Teleporter>().WaitCollision());
        //        transform.position = new Vector3(-4f, 1.1f);
        //
        //
        //    }
        //    else
        //    {
        //        StartCoroutine(collision.gameObject.GetComponent<Teleporter>().WaitCollision());
        //        transform.position = new Vector2(4f, 1.1f);
        //    }
        //}
    }
}
