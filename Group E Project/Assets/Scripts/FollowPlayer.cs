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
    private Rigidbody2D rb;

    private bool isActive = false;
    public float activationDelay = 2.0f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (player != null)
        {
            targetPosition = player.position;
        }

        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;

        StartCoroutine(ActivateSnowball());
    }

    private IEnumerator ActivateSnowball()
    {
        yield return new WaitForSeconds(activationDelay);
        isActive = true;
        rb.isKinematic = false;
    }

    private void Update()
    {
        if (!isActive)
        {
            return;
        }

        if (player != null)
        {
            timeSinceLastUpdate += Time.deltaTime;
            if (timeSinceLastUpdate >= updateInterval)
            {
                targetPosition = player.position;
                timeSinceLastUpdate = 0.0f;
            }

            Vector3 direction = (targetPosition - transform.position).normalized;
            rb.AddForce(direction * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isActive)
        {
            return;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null)
            {
                float damage = 20.0f;
                player.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}