using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public float maxHealth = 10;
    private float currentHealth;
    public GameObject Player;
    public GameObject AttackCollider;
    public float PlayerDistance;
    public float AttackTime = 0;
    public float MaxAttackTime = 0.2f;
    public float AttackCooldown = 2.0f;
    public bool Attack;
    Rigidbody2D rb;


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
        AttackCollider.GetComponent<Collider2D>().enabled = false;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
        PlayerDistance = Vector2.Distance(this.transform.position, Player.transform.position);
        if (PlayerDistance <= 15)
        {
            if (this.transform.position.x > Player.transform.position.x)
            {
                transform.localRotation = Quaternion.Euler(0, -180, 0);
            }
            else {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(Player.transform.position.x, transform.position.y), 0.005f);
        }
        else {
            Move();
        }
        if (PlayerDistance <= 2) {
            Attack = true;
            Debug.Log("1");
        }
        if (Attack == true)
        {
            AttackCollider.GetComponent<Collider2D>().enabled = true;
            AttackTime += Time.deltaTime;
            Debug.Log("2");
        }
        if (AttackTime >= MaxAttackTime)
        {
            AttackCollider.GetComponent<Collider2D>().enabled = true;
            AttackTime = 0;
            Attack = false;
            Debug.Log("3");
        }
    }

    private void Move()
    {
        if (isMovingRight)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            if (transform.position.x > maxX)
            {
                isMovingRight = false;
                
            }
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            transform.Translate(Vector2.left * speed * Time.deltaTime * -1);
            if (transform.position.x < minX)
            {
                isMovingRight = true;
                
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if (collision.gameObject.tag == "Player")
        // {
        //     Player player = collision.gameObject.GetComponent<Player>();
        //     if (player != null)
        //     {
        //         TakeDamage(player.damage);
        //     }
        // }

        // if (collision.gameObject.CompareTag("Player"))
        // {
        //     collision.gameObject.GetComponent<Player>().TakeDamage(2); 
        // }
    }

    public void TakeDamage(float damage)
    {
        float PlayerDistances = Vector2.Distance(this.transform.position, Player.transform.position);
        if (transform.rotation.y == 180)
        {
            rb.AddForce(transform.right  * 1200 * 1);
        }
        else {
            rb.AddForce(transform.right  * 1200 * -1);
        }
        Debug.Log("Damaged!");
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
