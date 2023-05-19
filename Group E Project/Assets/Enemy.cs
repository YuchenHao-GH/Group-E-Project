using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    public float damage;
    public float flashTime;
    private Color originalColor;
    private Player playerHealth;
     private Rigidbody2D rb;
    // Start is called before the first frame update
    public void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
        
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }
    public void Knockback(int direction)
    {
        rb.AddForce(Vector2.right * 20000 * direction);
    }
    public void SwordKnockback (int direction)
    {
        rb.AddForce(Vector2.right * 10000 * direction);
    }
  



    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            if(playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }
}
