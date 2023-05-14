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
    // Start is called before the first frame update
    public void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
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
