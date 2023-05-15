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
    private float maxspeed = 15f;
    public GameObject mostrecentcheckpoint;
    public float damage = 5;
    public float startingHealth = 10;
    public float currentHealth;
    public Animator animator;
    public float speed = 0.5f;
    public float jumpSpeed;
    public float runSpeed = 550.0f;
    private BoxCollider2D playerFeet;
    private bool isGround;


    private Vector2 groundNormal = Vector2.up;
    public float maxRotationAngle = 45f;
    public float rotationSpeed;

    public float tiltSpeed = 20f;
    public float maxTiltAngle = 45f;
    private float horizontalInput;
    private AnimatorControllerParameter[] animationCParameter;
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerFeet = GetComponent<BoxCollider2D>();
        int parameters = animator.parameterCount;
        animationCParameter = new AnimatorControllerParameter[parameters];
    }

    private void Awake()
    {
        currentHealth = startingHealth;
    }

    // public void RemoveAnimations()
    // {
        
    // {
    //     foreach(AnimatorControllerParameter p in animationCParameter)
    //     {
    //         animator.SetBool(p.name, false);
    //     }
    // }
    // }
    public void TakeDamage(float damage)
    {
        animator.SetTrigger("IsHit");
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            StartCoroutine(DisableHit());
        }
        else
        {
            StartCoroutine(ChangeState());
        }
    }

    IEnumerator DisableHit()
    {
        Debug.Log("Yes!");
        animator.SetTrigger("Die");
        yield return new WaitForSeconds(2f);
        Die();
        //Invoke("Die", 1f);
    }

    IEnumerator ChangeState()
    {
        yield return new WaitForSeconds(1f);
        
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Flip();
        Run();
        Jump();
        CheckGrounded();
        SwitchAnimation();
        
        
    
        //if (horizontalforce > 0)
        //{
            //transform.localScale = new Vector3(1, 1, 1);
        //}
        //else if (horizontalforce < 0)
        //{
            //transform.localScale = new Vector3(-1, 1, 1);
        //}
       
        //if (Input.GetButtonDown("Jump") && grounded == true) 
        //{
            //rb.AddForce(transform.up * 120000);
            //rb.velocity = new Vector2(rb.velocity.y,speed);
            //animator.SetBool("IsRun", true);
        //}
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
            
        }
        if (downramped == true)
        {
           animator.SetBool("IsRun", false);
           animator.SetBool("IsWalk", false);
            animator.SetBool("IsIdle", false);

           animator.SetBool("IsSliding", true);
        }
        if(rb.velocity.magnitude <= maxspeed)
        {
            //rb.AddForce(transform.right * horizontalforce * 800);
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

    void CheckGrounded()
    {
        isGround = playerFeet.IsTouchingLayers(LayerMask.GetMask("ground"));
    }

    void Flip()
    {
        bool plyerHasXAxisSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        if(plyerHasXAxisSpeed)
        {
           
        }
    }

    void Run()
    {
        
        float moveDir = Input.GetAxis("Horizontal");
        bool plyerHasXAxisSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        if(rb.velocity.magnitude <= maxspeed)
        {
            rb.AddForce(transform.right * moveDir * 200);
        }
         if (moveDir > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            if(rb.velocity.x < 2f && rb.velocity.x > -2f && (moveDir > 0 || moveDir < 0))
        {
            animator.SetBool("IsRun", false);
           animator.SetBool("IsSliding", false);
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsWalk", true);
        }

        else if(rb.velocity.x > 2f || rb.velocity.x < -2f && (moveDir > 0 || moveDir < 0))
        {
        animator.SetBool("IsSliding", false);
           animator.SetBool("IsWalk", false);
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsRun", true);
        }
        }
        else if (moveDir < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            if(rb.velocity.x < 2f && rb.velocity.x > -2f && (moveDir > 0 || moveDir < 0))
        {
            animator.SetBool("IsRun", false);
           animator.SetBool("IsSliding", false);
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsWalk", true);
        }

        else if(rb.velocity.x > 2f || rb.velocity.x < -2f && (moveDir > 0 || moveDir < 0))
        {
        animator.SetBool("IsSliding", false);
           animator.SetBool("IsWalk", false);
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsRun", true);
        }
        }
        else if (moveDir == 0 && rb.velocity.x != 0)
        {
            animator.SetBool("IsRun", false);
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsWalk", false);
            animator.SetBool("IsSliding", true);
        }
        else
        {
          animator.SetBool("IsRun", false);
           animator.SetBool("IsWalk", false);
            animator.SetBool("IsSliding", false);
            animator.SetBool("IsIdle", true);
        }
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if(isGround)
            {
                rb.AddForce(Vector2.up * 2450, ForceMode2D.Impulse);
                animator.SetBool("IsJump", true);
                
                //Vector2 jumpVel = new Vector2(0.0f, jumpSpeed);
            }
        }
    }

    void SwitchAnimation()
    {
        if(animator.GetBool("IsJump"))
        {
            if(rb.velocity.y < 0.0f)
            {
                animator.SetBool("IsJump", false);
                animator.SetBool("IsFall", true);
            }
        }
        else if(isGround)
        {
            animator.SetBool("IsFall", false);
            
        }
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
        if (collider.gameObject.tag== "ReloadZone")
        {
            rb.velocity = new Vector2(0, 0);
            transform.position = mostrecentcheckpoint.transform.position;
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
            float pushForce = 500f;
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
    void Attack()
    {
        
    }
}
