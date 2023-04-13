using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    Collider2D SwordCollider;
    public int damage = 1;
    public float AttackTime = 0;
    public float MaxAttackTime = 1f;
    private bool Attack = false;
    // Start is called before the first frame update
    void Start()
    {
        SwordCollider = GetComponent<Collider2D>();
        SwordCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown("SwordAttack"))
        {
            Attack = true;
            Debug.Log("1");
        }
        if (Attack == true)
        {
            SwordCollider.enabled = true;
            AttackTime += Time.deltaTime;

            Debug.Log("2");
        }
        if (AttackTime >= MaxAttackTime)
        {
            SwordCollider.enabled = false;
            AttackTime = 0;
            Attack = false;
            Debug.Log("3");
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            Enemy enemy = collider.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                
            }
        }
    }
}
