using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    Collider2D SwordCollider;
    public int damage = 1;
    public float AttackTime = 0;
    private float MaxAttackTime = 0.05f;
    private bool Attack = false;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        SwordCollider = GetComponent<Collider2D>();
        SwordCollider.enabled = false;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown("SwordAttack"))
        {
            Attack = true;
        }
        if (Attack == true)
        {
            SwordCollider.enabled = true;
            AttackTime += Time.deltaTime;
            anim.SetBool("Attack", true);
            
        }
        if (AttackTime >= MaxAttackTime)
        {
            anim.SetBool("Attack", false);
            SwordCollider.enabled = false;
            AttackTime = 0;
            Attack = false;
            
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
