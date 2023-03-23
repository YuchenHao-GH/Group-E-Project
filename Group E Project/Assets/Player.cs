using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float horizontalforce; 
    public bool grounded;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalforce = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && grounded == true) 
        {
             rb.AddForce(transform.up * 1200);
        }
    }
    void FixedUpdate()
    {
        LayerMask mask = LayerMask.GetMask("ground");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 2, mask);
        rb.AddForce(transform.right * horizontalforce * 20);
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "ground")
        {
            grounded = true;
        } 
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "ground")
        {
            grounded = false;
        }
    }
}
