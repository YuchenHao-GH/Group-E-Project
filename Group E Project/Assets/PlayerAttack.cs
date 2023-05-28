using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float swordDamage;
    private Animator anim;
    public float startTime;
    public float time;
    private PolygonCollider2D collider2D;

    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        collider2D = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        SwordAttack();
    }

    void SwordAttack()
    {
        if(Input.GetButtonDown("SwordAttack"))
        {
            SoundManager.PlayAttackSoundClip();
            anim.SetTrigger("Attack");
            StartCoroutine(StartAttack());
        }
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
            other.GetComponent<Enemy>().TakeDamage(swordDamage);
            other.GetComponent<Enemy>().Knockback(1, 0);

        }
    }
}
