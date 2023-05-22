using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraMove : MonoBehaviour
{
    public Vector2 MouseSens;
    public Transform headJoint;

    float xRotation = 0f;

    [SerializeField]
    Animator anim;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Vector2 Mouse_Input = new Vector2(Input.GetAxis("Mouse X") * MouseSens.x * Time.deltaTime,
                                          Input.GetAxis("Mouse Y") * MouseSens.y * Time.deltaTime);

        anim.SetFloat("Mouse", Input.GetAxis("Mouse X"));

        xRotation -= Mouse_Input.y;
        xRotation = Mathf.Clamp(xRotation, -90f, 70f);
            
        headJoint.transform.eulerAngles = new Vector3(xRotation, headJoint.transform.eulerAngles.y, headJoint.transform.eulerAngles.z);
        transform.Rotate(Vector3.up * Mouse_Input.x);

    }
}
