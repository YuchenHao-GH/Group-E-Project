using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerAttack : MonoBehaviour
{
    public float swordDamage;
    private Animator anim;
    public float startTime;
    public float time;
    private PolygonCollider2D collider2D;
    public Rigidbody2D Player;

    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        collider2D = GetComponent<PolygonCollider2D>();
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
                    if (touch.phase == TouchPhase.Began && touch.position.x > Screen.width / 2.0f && touch.position.y > Screen.height / 2.0f)
                    {
                    SwordAttack();
                    }
            }
        }
            }
    }

    public void Test() 
    {
         StartCoroutine(StartAttack());
    }

    void SwordAttack()
    {
      
            Debug.Log("Hi");
            SoundManager.PlayAttackSoundClip();
            anim.SetTrigger("Attack");
            StartCoroutine(StartAttack());
        }

    IEnumerator StartAttack()
    {
        yield return new WaitForSeconds(startTime);
        collider2D.enabled = true;
        StartCoroutine(disableHitBox());
    }

    IEnumerator disableHitBox()
    {
        yield return new WaitForSeconds(time);
        collider2D.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Player.AddForce(transform.right * 525, ForceMode2D.Impulse);
            other.GetComponent<Enemy>().TakeDamage(swordDamage);
            other.GetComponent<Enemy>().Knockback(1, 0);

        }
    }
}
