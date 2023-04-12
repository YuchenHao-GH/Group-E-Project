using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public float maxHealth = 10;
    private float currentHealth;

    private bool isMovingRight = true;
    public float moveDistance = 2f;

    private Vector3 originalPosition;
    private float minX;
    private float maxX;

    private void Start()
    {
        currentHealth = maxHealth;
        originalPosition = transform.position;
        minX = originalPosition.x - moveDistance;
        maxX = originalPosition.x + moveDistance;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (isMovingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            if (transform.position.x > maxX)
            {
                isMovingRight = false;
            }
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            if (transform.position.x < minX)
            {
                isMovingRight = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null)
            {
                TakeDamage(player.damage);
            }
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(2); 
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
