using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float speed = 5f;
    private Transform player;
    public float updateInterval = 1.0f; 
    private float timeSinceLastUpdate = 0.0f;
    private Vector3 targetPosition;
    private Rigidbody2D rb;
    public float maxspeed = 15;
    private Rigidbody2D playerrb;
    private CircleCollider2D circle;

    private bool isActive = false;
    public float activationDelay = 2.0f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerrb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        circle = GetComponent<CircleCollider2D>();
        if (player != null)
        {
            targetPosition = player.position;
        }

        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;

        StartCoroutine(ActivateSnowball());
    }

    private IEnumerator ActivateSnowball()
    {
        yield return new WaitForSeconds(activationDelay);
        isActive = true;
        rb.isKinematic = false;
    }

    private void Update()
    {
        //int layer_mask = LayerMask.GetMask("ground");
        //RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), transform.right, 10f, layer_mask);
       // if (hit)
       // {
         //   rb.AddForce(transform.up * 100000 * Time.deltaTime);
      //  }
        InvokeRepeating("AdjustSpeed", 6, 3);
        if (!isActive)
        {
            return;
        }

        if (player != null)
        {
            timeSinceLastUpdate += Time.deltaTime;
            if (timeSinceLastUpdate >= updateInterval)
            {
                targetPosition = player.position;
                timeSinceLastUpdate = 0.0f;
            }

            Vector3 direction = (targetPosition - transform.position).normalized;
            if (rb.velocity.x <= maxspeed)
            {
                rb.AddForce(direction * speed * Time.deltaTime);
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isActive)
        {
            return;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null && player.isdead == false)
            {

                float damage = 20.0f;
                player.TakeDamage(damage);
            }

        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<CapsuleCollider2D>(), circle);
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<BoxCollider2D>(), circle);

        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            collider.GetComponent<Enemy>().TakeDamage(1);
            collider.GetComponent<Enemy>().Knockback(1, 0);


        }
    }
    public void AdjustSpeed()
    {
        
        if (player.position.x - transform.position.x > 10 )
        {
            maxspeed = playerrb.velocity.x + 1;
        }
        maxspeed = playerrb.velocity.x + 0.1f;
        if (maxspeed <= 10)
        {
            maxspeed = 10;
        }
    }
}