using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    Collider2D AttackCollider;
    public float Cooldown = 0;
    private Animator animator;
    public GameObject player;
    public float test;
    // Start is called before the first frame update
    void Start()
    {
        AttackCollider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        test = Vector2.Distance(player.transform.position, transform.position);
        animator.SetBool("Walking", true);
        if (test <= 10 && test >= -10)
        {
        if (Cooldown <= 1.5f)
        {
            Cooldown += Time.deltaTime;
        }
        }
        
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Player player = collider.gameObject.GetComponent<Player>();
            if (player != null && Cooldown >= 1.5f)
            {
                animator.SetBool("Walking", false);
                Cooldown = 0;
                SoundManager .PlayDevilAttackSoundClip();
                animator.SetTrigger("Attack");
                player.TakeDamage(1f);   
            }
        }
    }
}
