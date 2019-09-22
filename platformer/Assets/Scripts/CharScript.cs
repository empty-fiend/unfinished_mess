using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharScript : MonoBehaviour
{
    public float walkSpeed = 3f, runSpeed = 5f, jumpForce = 7f, JumpTime = 0.25f;
    public LayerMask whatIsGround;
    public Transform groundCheck, bgPlatform;
    bool facingRight = true, grounded, isJumping;
    float groundRadius = 0.2f, speed, jumpTimeCounter;
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
            isJumping = true;
            jumpTimeCounter = JumpTime;
            anim.SetBool("Ground", false);
            rb.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetButton("Jump") && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
                isJumping = false;

        }

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
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