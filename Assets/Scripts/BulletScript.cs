using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float BulletSpeed;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(transform.right * 1 * BulletSpeed * Time.deltaTime);
    }
}
