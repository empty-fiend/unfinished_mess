using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharScript : MonoBehaviour
{
    public float walkSpeed = 10f, runSpeed = 20f, jumpForce = 100f;
    public LayerMask whatIsGround;
    public Transform groundCheck, bgPlatform;
    bool facingRight = true, grounded;
    float groundRadius = 0.2f, speed;
    Animator anim;
    Rigidbody2D rb;
   



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        speed = walkSpeed;
    }

    private void Update()
    {
        if (grounded && Input.GetButtonDown("Jump"))
        {
            anim.SetBool("Ground", false);
            rb.AddForce(new Vector2(0, jumpForce));
        }

        if (Input.GetButtonDown("Run"))
            speed = runSpeed;
        else if (Input.GetButtonUp("Run"))
            speed = walkSpeed;

    }


    // Update is called once per frame
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Ground", grounded); 
        float move = Input.GetAxisRaw ("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(move));
        rb.velocity = new Vector2(move * speed, rb.velocity.y);
        
        if (move > 0 && !facingRight) 
            Flip(); 
        else if (move < 0 && facingRight)
            Flip();
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}