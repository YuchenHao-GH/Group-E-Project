using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDevil : Enemy
{
    public float speed;
    public float startWaitTime;
    private float waitTime;
    public Transform movePos;
    public Transform leftDownPos;
    public Transform rightUpPos;
    public Transform player;
    private Animator animator;
    public float cooldown = 1;
    bool disablecollision = false;
    CapsuleCollider2D collider1;
    BoxCollider2D collider2;
    
    // Start is called before the first frame update
    public void Start()
    {
        animator = GetComponent<Animator>();
        base.Start();
        waitTime = startWaitTime;
        collider1= GetComponent<CapsuleCollider2D>();
        collider2 = GetComponent<BoxCollider2D>();
    }
   

    // Update is called once per frame
    public void Update()
    {
        if (player.transform.position.x < transform.position.x) {
            transform.localScale = new Vector3(-1, 1, 1);
            
        }
        else {
             transform.localScale = new Vector3(1, 1, 1);
        }
          if(health <= 0)
        {
            disablecollision = true;
            collider2.enabled = false;
            animator.SetTrigger("Die");
            cooldown-= Time.deltaTime;
            if (cooldown < 0)
            {
                SoundManager.PlayDevilDeathSoundClip();
                Destroy(gameObject);
            }
        }
    }
   void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player" && disablecollision == true)
        {
            Physics2D.IgnoreCollision(collider.gameObject.GetComponent<CapsuleCollider2D>(), collider1);
        }
    }
}
