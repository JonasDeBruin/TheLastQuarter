using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float EnemySpeed;

    [SerializeField] private int EnemyDamage;
    HPcontroller _healthcontroller;

    private void Start()
    {
        _healthcontroller = FindObjectOfType<HPcontroller>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(transform.right * -1 * EnemySpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            Damage();
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }

    }

    void Damage()
    {
        _healthcontroller.PlayerHP = _healthcontroller.PlayerHP - EnemyDamage;
        _healthcontroller.UpdateHealth();
    }
}
