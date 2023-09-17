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
        
        
    }

    public void TakeDamage(float damage)
    {
        SoundManager.PlayDevilDeathSoundClip();
        health -= damage;
    }
    public void Knockback(int direction, int playermomentum)
    {
        rb.AddForce(Vector2.right * 2 * (rb.velocity.x/5) * direction);
        rb.AddForce(Vector2.up * 3 * (rb.velocity.x/10));
    }
    public void SwordKnockback (int direction)
    {
        rb.AddForce(Vector2.right * 10000 * direction);
    }
  



   
}
