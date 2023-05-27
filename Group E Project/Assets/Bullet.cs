using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int damage;

    public float lifeTime = 1f;
    private float timer = 0f; 

    private void Start()
    {
        //Invoke("DestroyBullet", lifeTime);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= lifeTime)
        {
            //Destroy(gameObject);
        }
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                if (transform.position.x > enemy.transform.position.x)
                {
                    enemy.Knockback(-1, 0);
                }
                else {
                    enemy.Knockback(1, 0);
                }
            }
            Destroy(gameObject);
        }
    }

    //private void DestroyBullet()
    //{
        //Destroy(gameObject, 0f);
    //}
}
