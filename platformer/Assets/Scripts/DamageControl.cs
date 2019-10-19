using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //So you can use SceneManager


public class DamageControl : MonoBehaviour
{
	public LayerMask whoIsTheEnemy;
	public float invicibilityTime = 2.5f;
	bool enemyTouched = false, enemyKill = false, invicible = false;
	float invincebilityCounter;
  Health HealthManager;
  SpriteRenderer playerSprite;
	Rigidbody2D rb;

  		IEnumerator PlayerBlink()
  		{
  			while (invicible == true)
  			{
  				playerSprite.enabled = false;
  				yield return new WaitForSeconds(0.1f);
  				playerSprite.enabled = true;
  				yield return new WaitForSeconds(0.1f);
  			}
  		}
    // Start is called before the first frame update
    void Start()
    {
        invicible = false;
        rb = GetComponent<Rigidbody2D>();
        playerSprite = this.gameObject.GetComponent<SpriteRenderer>();
        HealthManager = GetComponent<Health>();

    }

    // Update is called once per frame
    void Update()
    {

      				if (HealthManager.health > 0)
      				{
      					enemyTouched = Physics2D.IsTouchingLayers(this.GetComponent<Collider2D>(), whoIsTheEnemy);
      					if (enemyTouched && !invicible)
      					{
      						rb.AddForce(Vector3.left*500, ForceMode2D.Impulse);
      						HealthManager.health -= 1;
      						invincebilityCounter = invicibilityTime;
      						invicible = true;
      					}
      					if (invicible && invincebilityCounter > 0)
      					{
      						StartCoroutine(PlayerBlink());
      						invincebilityCounter -= Time.deltaTime;
      					}
      					else
      						if (invincebilityCounter < 0)
      						{
      							invicible = false;
      							playerSprite.enabled = true;
      						}
      				}
      				else
      					SceneManager.LoadScene("SampleScene");
    }
}
