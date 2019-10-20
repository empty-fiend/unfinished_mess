using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
  bool PickedUp = false;
  Collider2D heart;
  Health HealthManager;
    // Start is called before the first frame update
    void Start()
    {
      HealthManager = GameObject.FindWithTag("Player").GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
      PickedUp = Physics2D.IsTouching(this.GetComponent<Collider2D>(), GameObject.FindWithTag("Player").GetComponent<Collider2D>());
      if (PickedUp == true)
      {
        if (this.gameObject.tag == GameObject.FindWithTag("heart").tag && HealthManager.health < HealthManager.numOfHearts)
        {
          HealthManager.health += 1;
          this.gameObject.SetActive(false);
          PickedUp = false;
        }
        else
        if (this.gameObject.tag == GameObject.FindWithTag("extraLife").tag)
        {
          HealthManager.lifeCounter += 1;
          this.gameObject.SetActive(false);
          PickedUp = false;
        }

      }

    }
}
