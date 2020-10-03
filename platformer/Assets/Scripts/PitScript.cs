using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitScript : MonoBehaviour
{
  DamageControl DamageControl;
  Health HealthManager;
  Transform playerPos;
  bool getCollision;
    // Start is called before the first frame update
    void Start()
    {
      playerPos = GameObject.FindWithTag("Player").transform;
      HealthManager = GameObject.FindWithTag("Player").GetComponent<Health>();
      DamageControl = GameObject.FindWithTag("Player").GetComponent<DamageControl>();
    }

    // Update is called once per frame
    void Update()
    {
      transform.position = new Vector3(playerPos.position.x, transform.position.y);
      getCollision = Physics2D.IsTouching(this.GetComponent<Collider2D>(), GameObject.FindWithTag("Player").GetComponent<Collider2D>());
      if (getCollision)
      {
        HealthManager.health -= HealthManager.health;
        this.gameObject.SetActive(false);
      }
    }
}
