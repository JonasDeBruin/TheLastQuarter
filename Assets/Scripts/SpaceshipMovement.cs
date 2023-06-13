using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipMovement : MonoBehaviour
{
    public float Speed;
    public GameObject Bullet;

    public float minY;
    public float maxY;

    public float minX;
    public float maxX;

    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D) && transform.position.x < maxX)
        {
            transform.Translate(transform.right * -1 * Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W) && transform.position.y < maxY)
        {
            transform.Translate(transform.up * -1 * Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A) && transform.position.x > minX)
        {
            transform.Translate(transform.right * 1 * Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S) && transform.position.y > minY)
        {
            transform.Translate(transform.up * 1 * Speed * Time.deltaTime);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            Vector2 myPos = new Vector2(transform.position.x, transform.position.y);
            Instantiate(Bullet, myPos, Quaternion.identity);
        }
    }
}
