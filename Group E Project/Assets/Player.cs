using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float horizontalforce; 
    public bool grounded;
    public bool ramped;
<<<<<<< Updated upstream
    private float maxspeed = 10f;
=======
    private float maxspeed = 7f;

    private Vector2 groundNormal = Vector2.up;
    public float maxRotationAngle = 45f;
    public float rotationSpeed;

    public float tiltSpeed = 20f;
    public float maxTiltAngle = 45f;
    private float horizontalInput;

>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
             rb.AddForce(transform.up * 170000);
=======
             rb.AddForce(transform.up * 140000);
>>>>>>> Stashed changes
        }
    }
    void FixedUpdate()
    {
        Debug.Log(rb.velocity.magnitude);
        LayerMask mask = LayerMask.GetMask("ground");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 2, mask);
<<<<<<< Updated upstream
        
        if (ramped == true)
        {
            rb.AddForce(transform.right * 8000);
=======
        if (ramped == true)
        {
            rb.AddForce(transform.right * 7000);
>>>>>>> Stashed changes
        }
        if(rb.velocity.magnitude <= maxspeed)
        {
            rb.AddForce(transform.right * horizontalforce * 1000);
        }
<<<<<<< Updated upstream
        
=======
        //maintain vertical on slope (testing)
        //if (rb.freezeRotation == false)
       // {
           // RaycastHit2D hit2 = Physics2D.Raycast(transform.position, Vector2.right);
          //  RaycastHit2D hit3 = Physics2D.Raycast(transform.position, Vector2.down);
           // rb.rotation = 45;
            //groundNormal = hit2.normal;
      
            
        //float angle = Vector2.Angle(Vector2.up, groundNormal);
        //if (angle > maxRotationAngle)
       // {
          //  Quaternion targetRotation = Quaternion.FromToRotation(Vector2.up, groundNormal);
         //   rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime));
       // }
        //}
        // // tilted center of gravity
        // float tiltAngle = -horizontalforce * tiltSpeed;
        // tiltAngle = Mathf.Clamp(tiltAngle, -maxTiltAngle, maxTiltAngle);
        // transform.rotation = Quaternion.Euler(0f, 0f, tiltAngle);
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
=======
            //rb.freezeRotation = false;
>>>>>>> Stashed changes
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
            //rb.rotation = 0;
            //rb.freezeRotation = true;
        }
        if(collider.gameObject.tag == "ramp")
        {
            ramped = false;
        }
    }
    
}
