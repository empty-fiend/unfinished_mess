using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
	public int health, numOfHearts;
	public Image[] hearts;
	public Sprite fullHeart, emptyHeart;
  public Transform player;
	public LayerMask whoIsTheEnemy;
	public Collider2D playerCol;
	public float invicibilityTime = 2.5f;
	bool enemyTouched = false, enemyKill = false, invicible = false;
	float invincebilityCounter;
	private SpriteRenderer playerSprite;
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
			rb = GetComponent<Rigidbody2D>();
			invicible = false;
			playerSprite = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
		if (health > numOfHearts)
			health = numOfHearts;
      for (int i = 0; i < hearts.Length; i++)
				{
					if (i < health)
						hearts[i].sprite = fullHeart;
		            else
						hearts[i].sprite = emptyHeart;

					if (i < numOfHearts)
						hearts[i].enabled = true;
					else
						hearts[i].enabled = false;
				}

				if (health > 0)
				{
					enemyTouched = Physics2D.IsTouchingLayers(playerCol, whoIsTheEnemy);
					if (enemyTouched && !invicible)
					{
						rb.AddForce(Vector3.left*500, ForceMode2D.Impulse);
						health -= 1;
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
					this.gameObject.SetActive(false);
    }
}
