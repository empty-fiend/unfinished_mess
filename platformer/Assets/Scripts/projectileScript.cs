using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileScript : MonoBehaviour
{
  public float speed;
  Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        Destroy(gameObject, 1.5f);
    }

    void OnTriggerExit2D(Collider2D other)
    {
      if (other.CompareTag("Player"))
        Destroy(gameObject);
    }

}
