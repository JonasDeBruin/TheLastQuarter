using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public float dampTime = 0.15f;
    public Vector3 offset;
    private Vector3 velocity = Vector3.zero;
    public Transform target;
    private Camera cam;

    private void Awake()
    {
        cam = GetComponent<Camera>();
    }
    void FixedUpdate()
    {
        if (target)
        {
            Vector3 point = cam.WorldToViewportPoint(target.position);
            Vector3 delta = target.position - cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
            Vector3 destination = transform.position + delta + offset;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }

    }
}
