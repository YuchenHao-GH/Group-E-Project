using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab; 
    public Transform firePoint; 
    public float bulletSpeed = 1000f;
    public int damage = 1;
    public Transform player;
    public float AttackTime = 0;
    public float MaxAttackTime = 1f;
    private bool Attack = false;
    public float Cooldown = 0f;
    public float CooldownTime = 1f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if ((Input.GetButtonDown("Fire") || Input.GetAxis("Fire") > 0) && Cooldown >= 5)
        {
            Fire(); 
        } 
        if (Cooldown <= 5)
        {
            Cooldown+= Time.deltaTime;
        }

    }

    void Fire()
    {
        Cooldown = 0;
        SoundManager.PlayShootSoundClip();
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Vector2 bulletDirection = (Vector2)firePoint.position - (Vector2)player.position;
        bullet.GetComponent<Rigidbody2D>().velocity = bulletDirection.normalized * bulletSpeed;
        //Vector2 bulletVelocity = firePoint.right * bulletSpeed;
        //bullet.GetComponent<Rigidbody2D>().velocity = bulletVelocity;
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null)
        {
            bulletScript.SetDamage(damage);
        }
        Destroy(bullet, 0.3f);
       // Destroy(bullet.GetComponent<Rigidbody2D>());
        //bullet.transform.Translate(bulletVelocity * Time.deltaTime, Space.World);
    }
}
