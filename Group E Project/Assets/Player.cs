using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float horizontalforce; 
    public bool grounded;
    public bool ramped;
    public bool downramped;
    private float maxspeed = 12f;
    public GameObject mostrecentcheckpoint;
    public float damage = 5;
    public float startingHealth = 10;
    public float currentHealth;



    private Vector2 groundNormal = Vector2.up;
    public float maxRotationAngle = 45f;
    public float rotationSpeed;

    public float tiltSpeed = 20f;
    public float maxTiltAngle = 45f;
    private float horizontalInput;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalforce = Input.GetAxis("Horizontal");
       
        if (Input.GetButtonDown("Jump") && grounded == true) 
        {
             rb.AddForce(transform.up * 84000);
        }
        if (Input.GetButtonDown("Reload"))
        {
            rb.velocity = new Vector2(0, 0);
            transform.position = mostrecentcheckpoint.transform.position;
        }

    }
    void FixedUpdate()
    {
        
        LayerMask mask = LayerMask.GetMask("ground");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 2, mask);
        RaycastHit2D test = Physics2D.Raycast(transform.position, Vector2.down, 2, mask);

        if (test.collider!= null)
        {
            grounded = true;
        }
        else 
        {
            grounded = false;
        }
        
        if (ramped == true)
        {
            rb.AddForce(transform.right * 7500);
        }
        if (downramped == true)
        {
            rb.AddForce(transform.right * 7500);
        }
        if(rb.velocity.magnitude <= maxspeed)
        {
            rb.AddForce(transform.right * horizontalforce * 500);
        }
        //maintain vertical on slope (testing)
        // RaycastHit2D hit2 = Physics2D.Raycast(transform.position, Vector2.down);
        // if (hit2.collider != null)
        // {
        //     groundNormal = hit2.normal;
        // }
        // float angle = Vector2.Angle(Vector2.up, groundNormal);
        // if (angle > maxRotationAngle)
        // {
        //     Quaternion targetRotation = Quaternion.FromToRotation(Vector2.up, groundNormal);
        //     rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime));
        // }
        // // tilted center of gravity
        // float tiltAngle = -horizontalforce * tiltSpeed;
        // tiltAngle = Mathf.Clamp(tiltAngle, -maxTiltAngle, maxTiltAngle);
        // transform.rotation = Quaternion.Euler(0f, 0f, tiltAngle);
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "ground" || collider.gameObject.tag == "ramp" || collider.gameObject.tag == "downramp")
        {
           
        } 
        if(collider.gameObject.tag == "ramp" || collider.gameObject.tag == "downramp")
        {
            ramped = true;
            //rb.freezeRotation = false;
            //rb.rotation = 45;
        }
        if (collider.gameObject.tag == "downramp")
        {
          downramped = true;
        }
        if (collider.gameObject.tag == "checkpoint")
        {
            mostrecentcheckpoint = collider.gameObject;
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "ground" || collider.gameObject.tag == "ramp" || collider.gameObject.tag == "downramp")
        {
            
        }
        if(collider.gameObject.tag == "ramp" || collider.gameObject.tag == "downramp")
        {
            ramped = false;
            //rb.rotation = 0;
            //rb.freezeRotation = false;
        }
        if (collider.gameObject.tag == "downramp")
        {
          downramped = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Vector2 direction = transform.position - collision.transform.position;
            float distance = direction.magnitude;
            float pushForce = 1000f;
            GetComponent<Rigidbody2D>().AddForce(direction.normalized * pushForce, ForceMode2D.Impulse);
        }
    }
    public void AddHealth(float health)
    {
        currentHealth += health;

        if (currentHealth > startingHealth)
        {
            currentHealth = startingHealth;
        }
    }
}
