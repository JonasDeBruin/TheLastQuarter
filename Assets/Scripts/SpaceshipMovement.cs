using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipMovement : MonoBehaviour
{
    public float Speed;
    public GameObject Bullet;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(transform.right * -1 * Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(transform.up * -1 * Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(transform.up * 1 * Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(transform.right * 1 * Speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            Vector2 myPos = new Vector2(transform.position.x, transform.position.y);
            Instantiate(Bullet, myPos, Quaternion.identity);
        }
    }
}
