using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Arcade_Machine : MonoBehaviour
{
    public int GameSceneIndex;

    public TextMeshPro text;

    Camera cam;
    PlayerCameraMove camMove;
    PlayerMovement playerMove;

    public bool inRange = false;
    bool gameStarted = false;

    public Transform camPos;

    float moveTime = 0;
    public float moveDuration = 1;
    Vector3 startPos;
    Vector3 startRot;

    public List<GameObject> lights = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        inRange = true;
    }
    private void OnTriggerExit(Collider other)
    {
        inRange = false;
    }

    private void Start()
    {
        camMove = FindObjectOfType<PlayerCameraMove>();
        playerMove = FindObjectOfType<PlayerMovement>();
        cam = FindObjectOfType<Camera>();
        text.color = new Color(1, 1, 1, 0);
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }

    private void Update()
    {
        if (gameStarted)
        {
            text.color = new Color(1, 1, 1, 0);

            if (moveTime < moveDuration)
            {
                cam.transform.position = Vector3.Lerp(startPos, camPos.position, moveTime / moveDuration);
                cam.transform.eulerAngles= Vector3.Lerp(startRot, camPos.eulerAngles, moveTime / moveDuration);
                moveTime += Time.deltaTime;
                for (int i = 0; i < lights.Count; i++)
                {
                    float temp = lights[i].GetComponent<Light>().intensity;
                    lights[i].GetComponent<Light>().intensity -= temp * Time.deltaTime * 5;
                }
            }
            else if(lights[1].GetComponent<Light>().enabled)
            {
                for (int i = 0; i < lights.Count; i++)
                {
                    lights[i].GetComponent<Light>().enabled = false;
                }

                SceneManager.LoadScene(GameSceneIndex);
                //Start Game
            }
            
        }
        else if (inRange)
        {
            if(text.color.a < 1 && !gameStarted)
            {
                text.color += new Color(0, 0, 0, Time.deltaTime*2);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                gameStarted = true;
                camMove.on = false;
                playerMove.on = false;
                cam.GetComponent<Animator>().enabled = false;
                startPos = cam.transform.position;
                startRot = cam.transform.eulerAngles;
            }
        }
        else
        {
            if (text.color.a > 0)
            {
                text.color -= new Color(0, 0, 0, Time.deltaTime);
            }
        }
    }
}
