using System.Collections;
using UnityEngine;

namespace CharacterScripts.functions
{
  public class InvulScript : MonoBehaviour
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
          playerSprite.enabled = !playerSprite.enabled;
          yield return new WaitForSeconds(0.1f);
        }
      }
    }
  }
}
