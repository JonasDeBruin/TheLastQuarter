using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool doMovement = true;

    [Header ("Camera Pan")]
    public float panSpeed = 30f;
    public float panBorderThickness = 10f;
    public float minPanX = -20;
    public float maxPanX = 50;
    public float minPanZ = -50;
    public float maxPanZ = 25;
    [Header("Camera Zoom")]
    public float scrollSpeed = 5f;
    public float minScrollY = 10f;
    public float maxScrollY = 80f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            doMovement = !doMovement;
        }
        if (!doMovement) return;

        #region Camera Panning
        if ((Input.GetKey(KeyCode.W) || Input.mousePosition.y >= Screen.height - panBorderThickness) && transform.position.z < maxPanZ)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        else if ((Input.GetKey(KeyCode.S) || Input.mousePosition.y <= panBorderThickness) && transform.position.z > minPanZ)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if ((Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - panBorderThickness) && transform.position.x < maxPanX)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        else if ((Input.GetKey(KeyCode.A) || Input.mousePosition.x <= panBorderThickness) && transform.position.x > minPanX)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        #endregion

        #region Camera Zooming
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;

        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minScrollY, maxScrollY);

        transform.position = pos;

        #endregion
    }
}
