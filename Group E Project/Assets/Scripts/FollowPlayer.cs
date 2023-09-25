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

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (player != null)
        {
            targetPosition = player.position;
        }
    }

    private void Update()
    {
        if (player != null)
        {
            timeSinceLastUpdate += Time.deltaTime;
            if (timeSinceLastUpdate >= updateInterval)
            {
                targetPosition = player.position;
                timeSinceLastUpdate = 0.0f;
            }

            Vector3 direction = (targetPosition - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                float damage = 20.0f;
                player.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}