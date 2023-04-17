using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    Collider2D AttackCollider;
    // Start is called before the first frame update
    void Start()
    {
        AttackCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("Fortnite");
            Player player = collider.gameObject.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage(2f);
            }
        }
    }
}
