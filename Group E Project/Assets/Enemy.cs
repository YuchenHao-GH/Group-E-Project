using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public float health;
    public float damage;
    public float flashTime;
    private SpriteRenderer sr;
    private Color originalColor;
    // Start is called before the first frame update
    public void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
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
        FlashColor(flashTime);
    }

    public void FlashColor(float time)
    {
        sr.color = Color.red;
        Invoke("ResetColor",time);
    }

    public void ResetColor()
    {
        sr.color = originalColor;
    }
}
