using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShooterScript : MonoBehaviour
{
    public float maxHeight = 1.6f, distance = 1.5f, startTimeBtwShoots;
    public Transform playerCheck;
    public LayerMask whoIsYourEnemy;
    public GameObject projectile;
    private float timeBtwShoots;
    bool enemycol;
    enemyPatrolScript enemyPatrol;
    Transform playerPos;
    RaycastHit2D iSeeYou;
    Rigidbody2D rb;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
      anim = GetComponent<Animator>();
      playerPos = GameObject.FindWithTag("Player").transform;
      enemyPatrol = this.GetComponent<enemyPatrolScript>();
      rb = this.GetComponent<Rigidbody2D>();
      timeBtwShoots = startTimeBtwShoots;
    }

    // Update is called once per frame
    void Update()
    {
      anim.SetBool("enemyСol", enemycol);
      enemycol = Physics2D.IsTouchingLayers(this.GetComponent<Collider2D>(), enemyPatrol.whatIsGround);
      if (playerPos.position.y >= this.transform.position.y - maxHeight && playerPos.position.y < this.transform.position.y + maxHeight)
      playerCheck.transform.position = new Vector3(playerCheck.transform.position.x, playerPos.position.y - 0.3f);
      if (enemyPatrol.movingRight)
        iSeeYou = Physics2D.Raycast(playerCheck.position, Vector2.right, distance, whoIsYourEnemy);
      else
        if (!enemyPatrol.movingRight)
          iSeeYou = Physics2D.Raycast(playerCheck.position, Vector2.left, distance, whoIsYourEnemy);

      if (iSeeYou.collider)
      {
      enemyPatrol.isFiring = true;
      anim.SetBool("isFiring", enemyPatrol.isFiring);
      }
      else
        if (!iSeeYou.collider)
        {
          anim.SetBool("isFiring", enemyPatrol.isFiring);
          enemyPatrol.isFiring = false;
        }

      if (enemyPatrol.isFiring && enemycol)
        if (playerPos.position.y > this.transform.position.y + 1)
        {
          anim.SetBool("enemyСol", !enemycol);
          rb.velocity = Vector2.up * 10;
        }

      if (enemyPatrol.isFiring)
        if (timeBtwShoots <= 0)
        {
          Instantiate(projectile, enemyPatrol.groundDetection.transform.position, enemyPatrol.groundDetection.transform.rotation);
          timeBtwShoots = startTimeBtwShoots;
        }
      else
        timeBtwShoots -= Time.deltaTime;

    }
}
