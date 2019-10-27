using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPatrolScript : MonoBehaviour
{

    public float speed = 5f, distance = 2f;
    public bool isFiring = false;
    public Transform groundDetection;
    public LayerMask whatIsGround;
    Collider2D myDeathCollider;
    public bool movingRight = true;
    bool amIDeadYet, enemycol;
    public RaycastHit2D groundInfo;


    // Start is called before the first frame update
    void Start()
    {
      myDeathCollider = GameObject.FindWithTag("DeathCollider").GetComponent<Collider2D>();
      isFiring = false;
    }

    // Update is called once per frame
    void Update()
    {
      enemycol = Physics2D.IsTouchingLayers(this.GetComponent<Collider2D>(), whatIsGround);
      groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance, whatIsGround);
      amIDeadYet = Physics2D.IsTouching(myDeathCollider, this.GetComponent<Collider2D>());
      if (!isFiring && enemycol)
        transform.Translate(Vector2.right * speed * Time.deltaTime);
      if (groundInfo.collider == false)
      {
        if (movingRight == true)
        {
          transform.eulerAngles = new Vector3(0, -180, 0);
          movingRight = false;
        }
        else
        {
          transform.eulerAngles = new Vector3(0, 0, 0);
          movingRight = true;
        }
      }
      if (amIDeadYet)
      {
        GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().velocity = Vector2.up * 7;
        Destroy(gameObject);
      }
    }
}
