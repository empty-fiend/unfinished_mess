using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharScript : MonoBehaviour
{
    public float walkSpeed = 3f,
                 runSpeed = 5f,
                 jumpForce = 10f,
                 jumpTime = 3.5f;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    bool movingRight = true, grounded, isJumping;
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
        if (Input.GetButtonDown("Run"))
            speed = runSpeed;
        else if (Input.GetButtonUp("Run"))
            speed = walkSpeed;

        if (grounded)
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
        }

        if (Input.GetButton("Jump") && isJumping)
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
                isJumping = false;
        if (Input.GetButtonUp("Jump"))
            isJumping = false;


    }


    // Update is called once per frame
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Ground", grounded); 
        float move = Input.GetAxisRaw ("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(move));
        rb.velocity = new Vector2(move * speed, rb.velocity.y);
        if (move < 0 && movingRight)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            movingRight = false;
        }
        else if (move > 0 && movingRight == false)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            movingRight = true;
        }
    }
}