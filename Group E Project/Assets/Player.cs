using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

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
    public Animator animator;
    public float speed = 0.5f;
    public float jumpSpeed;
    public float runSpeed = 275.0f;
    private BoxCollider2D playerFeet;
    private bool isGround;
    private bool isRightRamp;
    public bool movingright;
    public bool movingleft;
    public Text text;
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

    public void Test(bool lol)
    {
        movingright = lol;
    }

    public void Left(bool lol)
    {
        movingleft = lol;
    }
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
        text.GetComponent<Timer>().Timing = false;
        animator.SetTrigger("Die");
        yield return new WaitForSeconds(2f);
        Die();
    }

    IEnumerator ChangeState()
    {
        yield return new WaitForSeconds(1f);
        
    }

    private void Die()
    {
        Destroy(gameObject);
        UIManager.Instance.PlayerDied();
    }

    // Update is called once per frame
    void Update()
    {
        
        Input.multiTouchEnabled = true; 
        float fingercount = 0;
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
            if (touch.position.x < Screen.width / 2.0f) {
                Run();
            }
            if (touch.phase == TouchPhase.Began && touch.position.x > Screen.width / 2.0f && touch.position.y < Screen.height / 2.0f)
            {
                Jump();
            }
            }
        }
        Flip();
    
   
        CheckGrounded();
        SwitchAnimation();
        LayerMask mask = LayerMask.GetMask("ground");
        LayerMask rightrampmask = LayerMask.GetMask("downramp");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 2, mask);
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position, transform.right, 2, rightrampmask);
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
    }
    void FixedUpdate()
    {
        if(movingright == true)
        {
             rb.AddForce(transform.right * 1 * 400);
        }
        if(movingleft == true)
        {
             rb.AddForce(transform.right * -1 * 400);
        }
    }

    void CheckGrounded()
    {
        isGround = playerFeet.IsTouchingLayers(LayerMask.GetMask("ground"));
        isRightRamp = playerFeet.IsTouchingLayers(LayerMask.GetMask("downramp"));
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
            float moveDir = 1;
            
        
        bool plyerHasXAxisSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        if(rb.velocity.magnitude <= maxspeed)
        {
            rb.AddForce(transform.right * moveDir * 100);
        }
         if (moveDir > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            if(rb.velocity.x < 2f && rb.velocity.x > -2f && (moveDir > 0 || moveDir < 0))
        {
            animator.SetBool("IsRun", false);
            animator.SetBool("IsSliding", false);
            animator.SetBool("isSlidingDownRight", false);
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsWalk", true);
        }

        else if(rb.velocity.x > 2f || rb.velocity.x < -2f && (moveDir > 0 || moveDir < 0))
        {
            animator.SetBool("IsSliding", false);
            animator.SetBool("IsWalk", false);
            animator.SetBool("IsIdle", false);
            animator.SetBool("isSlidingDownRight", false);
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
            animator.SetBool("isSlidingDownRight", false);
        }

        else if(rb.velocity.x > 2f || rb.velocity.x < -2f && (moveDir > 0 || moveDir < 0))
        {
            animator.SetBool("IsSliding", false);
            animator.SetBool("IsWalk", false);
            animator.SetBool("IsIdle", false);
            animator.SetBool("isSlidingDownRight", false);
            animator.SetBool("IsRun", true);
        }
        }
        else if (moveDir == 0 && rb.velocity.x != 0)
        {
            animator.SetBool("IsRun", false);
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsWalk", false);
            animator.SetBool("IsSliding", true);
            animator.SetBool("isSlidingDownRight", false);
        }
       
        else
        {
            animator.SetBool("IsRun", false);
            animator.SetBool("IsWalk", false);
            animator.SetBool("IsSliding", false);
            animator.SetBool("IsIdle", true);
            animator.SetBool("isSlidingDownRight", false);
        }
    }


public void TestJump()
{
     if(isGround || isRightRamp) {
     rb.AddForce(Vector2.up * 2450, ForceMode2D.Impulse);
     }
}

    void Jump()
    {
       
            if(isGround || isRightRamp)
            {
                rb.AddForce(Vector2.up * 2500, ForceMode2D.Impulse);
                animator.SetBool("IsJump", true);
                animator.SetBool("IsRun", false);
                animator.SetBool("IsWalk", false);
                animator.SetBool("IsSliding", false);
                animator.SetBool("IsIdle", false);
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
        else if(isGround || isRightRamp)
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
          
            StartCoroutine(DisableHit());
        }
        if (collider.gameObject.tag == "Enemy")
        {
             Debug.Log("Hola");
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
           
            rb.velocity = new Vector2 (rb.velocity.x, rb.velocity.y);
        }
    }

    public void AddHealth(float health)
    {
        SoundManager.PlayHealthUpSoundClip();
        currentHealth += health;

        if (currentHealth > startingHealth)
        {
            currentHealth = startingHealth;
        }
    }
}
