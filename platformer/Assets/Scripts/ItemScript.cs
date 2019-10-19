using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
  bool inTouched, PickedUp;
  public Collider2D Player;
  Health HealthManager;
  Collectibles Item;


    // Start is called before the first frame update
    void Start()
    {
      HealthManager = GetComponent<Health>();
      Item = GetComponent<Collectibles>();
    }

    // Update is called once per frame
    void Update()
    {
      PickedUp = Item.PickedUp;
      inTouched = Physics2D.IsTouching(this.GetComponent<Collider2D>(), Player);
      if (Item.PickedUp == true && inTouched)
      {
        this.gameObject.SetActive(false);
      }
    }
}
