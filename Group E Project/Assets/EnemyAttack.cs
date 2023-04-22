using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    Collider2D AttackCollider;
    public float Cooldown = 0;
    // Start is called before the first frame update
    void Start()
    {
        AttackCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Cooldown <= 1)
        {
            Cooldown += Time.deltaTime;
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("Fortnite");
            Player player = collider.gameObject.GetComponent<Player>();
            if (player != null && Cooldown >= 1)
            {
                Cooldown = 0;
                player.TakeDamage(2f);
            }
        }
    }
}
