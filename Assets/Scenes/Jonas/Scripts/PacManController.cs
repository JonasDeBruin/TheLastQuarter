using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacManController : MonoBehaviour
{
    Movement movementController;
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
    }
}
