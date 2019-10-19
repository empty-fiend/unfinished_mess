using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
  public bool PickedUp = false;
  bool getHeart = false;
  Collider2D heart;
  Health HealthManager;
    // Start is called before the first frame update
    void Start()
    {
      PickedUp = false;
      heart = GameObject.FindWithTag("heartContainer").GetComponent<Collider2D>();
      HealthManager = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
      getHeart = Physics2D.IsTouching(this.GetComponent<Collider2D>(), heart);
      if (getHeart == true && HealthManager.health < HealthManager.numOfHearts)
      {
          HealthManager.health += 1;
          PickedUp = true;
      }

    }
}
