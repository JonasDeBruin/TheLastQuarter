using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraMove : MonoBehaviour
{
    public bool AnimMode1, AnimMode2, AnimMode3 , AnimMode4;

    public Vector2 MouseSens;
    public Transform headJoint;

    public Vector2[] rotations = { };

    float xRotation = 0f;

    [SerializeField]
    Animator anim;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    private void FixedUpdate()
    {
        
    }

    void Update()
    {
        animCode();

        Vector2 Mouse_Input = new Vector2(Input.GetAxis("Mouse X") * MouseSens.x * Time.deltaTime,
                                          Input.GetAxis("Mouse Y") * MouseSens.y * Time.deltaTime);

        xRotation -= Mouse_Input.y;
        xRotation = Mathf.Clamp(xRotation, -90f, 70f);
            
        headJoint.transform.eulerAngles = new Vector3(xRotation, headJoint.transform.eulerAngles.y, headJoint.transform.eulerAngles.z);
        transform.Rotate(Vector3.up * Mouse_Input.x);

    }

    void animCode()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            turnOff();
            AnimMode1 = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            turnOff();
            AnimMode2 = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            turnOff();
            AnimMode3 = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            turnOff();
            AnimMode4 = true;
        }

        
        void turnOff()
        {
            AnimMode1 = false;
            AnimMode2 = false;
            AnimMode3 = false;
            AnimMode4 = false;
        }

        if (AnimMode1)
        {
            anim.SetFloat("Mouse", Input.GetAxis("Mouse X"));
        }
        else if (AnimMode2)
        {
            if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0f)
            {
                anim.SetFloat("Mouse", Input.GetAxisRaw("Horizontal"));
            }
            else
            {
                anim.SetFloat("Mouse", Input.GetAxis("Mouse X"));
            }
        }
        else if (AnimMode3)
        {
            if (Input.GetAxis("Vertical") == 0 && Mathf.Abs(Input.GetAxis("Horizontal")) > 0f)
            {
                anim.SetFloat("Mouse", Input.GetAxisRaw("Horizontal"));
            }
            else
            {
                anim.SetFloat("Mouse", Input.GetAxis("Mouse X"));
            }
        }
        else if (AnimMode4)
        {
            anim.SetFloat("Mouse", Mathf.Clamp((Input.GetAxis("Mouse X") + Input.GetAxis("Vertical")), -1f, 1f));
        }
    }
}
