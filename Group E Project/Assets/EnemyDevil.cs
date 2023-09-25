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
    private CapsuleCollider2D collider1;
    private BoxCollider2D collider2;
    
    // Start is called before the first frame update
    public void Start()
    {
        animator = GetComponent<Animator>();
        base.Start();
        waitTime = startWaitTime;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        collider2 = GetComponent<BoxCollider2D>();
        collider1 = GetComponent<CapsuleCollider2D>();
    }
   

    // Update is called once per frame
    public void Update()
    {
        //if (player.transform.position.x < transform.position.x) {
            //transform.localScale = new Vector3(-1, 1, 1);
            
        //}
        //else {
             //transform.localScale = new Vector3(1, 1, 1);
        //}
          if(health <= 0)
        {
            disablecollision = true;
            animator.SetTrigger("Die");
            cooldown-= Time.deltaTime;
            collider1.enabled = false;
            collider2.enabled = false;
            if (cooldown < 0)
            {
               
                Destroy(gameObject);
            }
        }
    }
   void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player" && disablecollision == true)
        {
            Physics2D.IgnoreCollision(collider.gameObject.GetComponent<CapsuleCollider2D>(), collider1);
            Physics2D.IgnoreCollision(collider.gameObject.GetComponent<CapsuleCollider2D>(), collider2);
            Physics2D.IgnoreCollision(collider.gameObject.GetComponent<BoxCollider2D>(), collider1);
            Physics2D.IgnoreCollision(collider.gameObject.GetComponent<BoxCollider2D>(), collider2);


        }
    }
}
