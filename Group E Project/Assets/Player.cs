using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float horizontalforce; 
    public bool grounded;
    public bool ramped;
    private float maxspeed = 10f;
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
             rb.AddForce(transform.up * 170000);
        }
    }
    void FixedUpdate()
    {
        Debug.Log(rb.velocity.magnitude);
        LayerMask mask = LayerMask.GetMask("ground");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 2, mask);
        
        if (ramped == true)
        {
            rb.AddForce(transform.right * 8000);
        }
        if(rb.velocity.magnitude <= maxspeed)
        {
            rb.AddForce(transform.right * horizontalforce * 1000);
        }
        
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "ground" || collider.gameObject.tag == "ramp")
        {
            grounded = true;
        } 
        if(collider.gameObject.tag == "ramp")
        {
            ramped = true;
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "ground" || collider.gameObject.tag == "ramp")
        {
            grounded = false;
        }
        if(collider.gameObject.tag == "ramp")
        {
            ramped = false;
        }
    }
}
