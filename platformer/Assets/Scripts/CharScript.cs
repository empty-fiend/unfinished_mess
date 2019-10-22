using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //So you can use SceneManager

public class CharScript : MonoBehaviour
{
    public float walkSpeed = 3f,
                 runSpeed = 5f,
                 jumpForce = 10f,
                 jumpTime = 3.5f;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    bool movingRight = true, isJumping;
    float speed, jumpTimeCounter;
    Animator anim;
    Rigidbody2D rb;

    bool grounded()
    {
      Vector2 position = groundCheck.position;
      Vector2 direction = Vector2.down;
      float distance = 0.1f;

      RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, whatIsGround);
      if (hit.collider != null )
      {
        return true;
      }
       return false;
    }


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

        if (grounded())
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
        anim.SetBool("Ground", grounded());
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
