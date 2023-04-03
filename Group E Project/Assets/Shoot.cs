using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab; 
    public Transform firePoint; 
    public float bulletSpeed = 10f;
    public int damage = 5;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Fire();
        }
    }

    void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Vector2 bulletVelocity = firePoint.right * bulletSpeed;
        bullet.GetComponent<Rigidbody2D>().velocity = bulletVelocity;
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null)
        {
            bulletScript.SetDamage(damage);
        }
       // Destroy(bullet.GetComponent<Rigidbody2D>());
        //bullet.transform.Translate(bulletVelocity * Time.deltaTime, Space.World);
    }
}
