using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public float damage = 2;
    public float damageInterval = 2f;
    private bool isDamaging = false;
    private float lastDamageTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isDamaging = true;
            lastDamageTime = Time.time;
            ApplyDamage(collision.GetComponent<Player>());
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isDamaging && Time.time - lastDamageTime >= damageInterval)
        {
            lastDamageTime = Time.time;
            ApplyDamage(collision.GetComponent<Player>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isDamaging = false;
        }
    }

    private void ApplyDamage(Player player)
    {
        player.TakeDamage(damage);
    }
}
