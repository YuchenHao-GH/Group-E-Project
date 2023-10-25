using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

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
    public float speed = 1f;
    public float jumpSpeed;
    public float runSpeed = 275.0f;
    private BoxCollider2D playerFeet;
    private bool isGround;
    private bool isRightRamp;
    public bool movingright;
    public bool movingleft;
    GameObject text;
    private Vector2 groundNormal = Vector2.up;
    public float maxRotationAngle = 45f;
    public float rotationSpeed;
    public Tile Ramp;
    public BoxCollider2D yes;
    public Camera Camera;
    public bool isdead = false;
    public float maxmaxspeed = 30;
    private UIManager uiManager;
    public float JumpGracePeriod;
    public float JumpTime;
    public bool WillJump = true;
    //private TimeRecord timeRecord;

    public float tiltSpeed = 20f;
    public float maxTiltAngle = 45f;
    private float horizontalInput;
    private AnimatorControllerParameter[] animationCParameter;
    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.Find("TimerText");
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerFeet = GetComponent<BoxCollider2D>();
        int parameters = animator.parameterCount;
        animationCParameter = new AnimatorControllerParameter[parameters];

        //timeRecord = FindObjectOfType<TimeRecord>();
        uiManager = FindObjectOfType<UIManager>();
    }

    private void Awake()
    {
        currentHealth = startingHealth;
        Screen.autorotateToLandscapeLeft = false;

        Screen.autorotateToLandscapeRight = false;
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
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            scoreManager.StopScore();
            StartCoroutine(DisableHit());
            Camera.GetComponent<CameraFollow>().Test();
            //Camera.GetComponent<CameraFollow>().enabled = false;
        }
        else
        {
            StartCoroutine(ChangeState());
        }
    }

    IEnumerator DisableHit()
    {
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
        scoreManager.StopScore();
        //Camera.GetComponent<CameraFollow>().Test();
        //stext.GetComponent<Timer>().Timing = false;
        Camera.GetComponent<CameraFollow>().Test();
        isdead = true;
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
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
        scoreManager.StopScore();
        Destroy(gameObject);
        uiManager.PlayerDied();
        Screen.autorotateToLandscapeLeft = true;

        Screen.autorotateToLandscapeRight = true;
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
                 if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            {
            if (touch.position.x < Screen.width / 2.0f) {
                movingright = true;
            }
            if (touch.phase == TouchPhase.Began && touch.position.x > Screen.width / 2.0f && touch.position.y < Screen.height / 2.0f)
            {
                JumpGracePeriod = Time.time;
                Jump();
            }
           
            
        }
            }
        }

        else if (Input.touchCount <= 0)
        {
            movingright = false;
            if (rb.velocity.x >= 1)
            {
                animator.SetBool("IsRun", false);
                animator.SetBool("IsSliding", true);
                animator.SetBool("isSlidingDownRight", false);
                animator.SetBool("IsIdle", false);
                animator.SetBool("IsWalk", false);
            }
            else if (rb.velocity.x < 1)
            {
                animator.SetBool("IsRun", false);
                animator.SetBool("IsSliding", false);
                animator.SetBool("isSlidingDownRight", false);
                animator.SetBool("IsIdle", true);
                animator.SetBool("IsWalk", false);
            }
        }

        else {
            
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
            if (test.collider.gameObject.GetComponent<Tilemap>().GetTile(new Vector3Int((int)transform.position.x, (int)transform.position.y - 2, (int)transform.position.z)) == Ramp)
            {
                ramped = true;
            }
            

        }
        else 
        {
            grounded = false;
        }
       
    }
    void FixedUpdate()
    {
        if ((isGround || isRightRamp) && WillJump == true)
        {
            rb.AddForce(Vector2.up * 2500, ForceMode2D.Impulse);
            animator.SetBool("IsJump", true);
            animator.SetBool("IsRun", false);
            animator.SetBool("IsWalk", false);
            animator.SetBool("IsSliding", false);
            animator.SetBool("IsIdle", false);
            WillJump = false;
        }
        if (movingright == true)
        {
             float moveDir = 1;
            
        
        bool plyerHasXAxisSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        if(rb.velocity.magnitude <= maxspeed)
        {
            rb.AddForce(transform.right * moveDir * 800);
        }
        else 
            {
                
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
        if(movingleft == true)
        {
             rb.AddForce(transform.right * -1 * 400);
        }
       
    }

    void CheckGrounded()
    {
        isGround = playerFeet.IsTouchingLayers(LayerMask.GetMask("ground"));
        if (playerFeet.IsTouchingLayers(LayerMask.GetMask("ground")))
            {
            JumpTime = Time.time;
            Debug.Log((float)(JumpTime - JumpGracePeriod) );
            if ((JumpTime - JumpGracePeriod)  <= 0.3)
            {
                WillJump = true;
            }

        }
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
            
    }

    void Jump()
    {
        
        }
    
    void SwitchAnimation()
    {
        if (animator.GetBool("IsJump"))
        {
            if (rb.velocity.y < 0.0f)
            {
                if (grounded == true)
                {
                    if (rb.velocity.x < 1)
                    {
                        animator.SetBool("IsFall", false);
                        animator.SetBool("IsIdle", true);
                        animator.SetBool("IsJump", false);
                      
                    }
                    else if (rb.velocity.x >= 1)
                    {
                        animator.SetBool("IsFall", false);
                        animator.SetBool("IsSliding", true);
                        animator.SetBool("IsJump", false);
                       
                    }
                }
                else
                {
                    animator.SetBool("IsJump", false);
                    animator.SetBool("IsFall", true);
                }
            }
        }
        else if (grounded==true)
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
        if (collider.gameObject.tag== "ReloadZone")
        {
            Camera.GetComponent<CameraFollow>().Test();
            StartCoroutine(DisableHit());
         
        }
        if (collider.gameObject.tag == "Enemy")
        {
            
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
            GameObject.Find("PlayerAttackArea").GetComponent<PlayerAttack>().enabled = false;
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
            Debug.Log("Hewllo");
            StartCoroutine(DisableHit());
            Camera.GetComponent<CameraFollow>().enabled = false;
            rb.velocity = new Vector2 (rb.velocity.x, rb.velocity.y);
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            collision.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
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
