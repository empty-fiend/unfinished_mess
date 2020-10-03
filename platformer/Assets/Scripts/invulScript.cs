using System.Collections;
using UnityEngine;

public class invulScript : MonoBehaviour
{
  private float _invulTimeCounter;

  public void Invul (bool getDamage, float invulTime, SpriteRenderer playerSprite)
  {
    if (getDamage)
    {
      _invulTimeCounter = invulTime;
    }

    if (getDamage && _invulTimeCounter > 0)
    {
      StartCoroutine(PlayerBlink());
      _invulTimeCounter -= Time.deltaTime;
    }
    if (_invulTimeCounter <= 0)
    {
        getDamage = false;
        playerSprite.enabled = true;
    }

    IEnumerator PlayerBlink()
    {
      while (getDamage)
      {
        playerSprite.enabled = false;
        yield return new WaitForSeconds(0.1f);
        playerSprite.enabled = true;
        yield return new WaitForSeconds(0.1f);
      }
    }
  }
}
