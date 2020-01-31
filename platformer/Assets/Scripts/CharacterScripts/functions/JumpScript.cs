using UnityEngine;

namespace CharacterScripts.functions
{
  public class JumpScript : MonoBehaviour
  {
    private bool _isJumping;
    private float _jumpTimeCounter;

    public void Jump (bool grounded, bool isButtonDown, float jumpForce, float jumpTime, Rigidbody2D rb)
    {
      if (grounded)
      {
        _isJumping = true;
        _jumpTimeCounter = jumpTime;
      }

      if (_isJumping && isButtonDown)
      {
        if (_jumpTimeCounter > 0)
        {
          rb.velocity = Vector2.up * jumpForce;
          _jumpTimeCounter -= Time.deltaTime;
        }
        else
          _isJumping = false;
      }

      if (!isButtonDown)
        _isJumping = false;
    }

    public void Jump (bool seeYa, bool grounded, float jumpForce, Rigidbody2D rb)
    {
      if (seeYa)
      {
        if (grounded)
        {
          rb.velocity = Vector2.up * jumpForce;
        }
      }
    }
  }
}
