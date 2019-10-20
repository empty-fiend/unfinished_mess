using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    public float speed = 5f, distance = 2f;
    public Transform groundDetection;
    private bool movingRight = true;
    public LayerMask whatIsGround;
    public Collider2D myDeathCollider;
    bool amIDeadYet;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance, whatIsGround);
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
        amIDeadYet = Physics2D.IsTouching(myDeathCollider, this.GetComponent<Collider2D>());
        if (amIDeadYet)
        {
            this.gameObject.SetActive(false);
            GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().velocity = Vector2.up * 5;
        }

    }
}
