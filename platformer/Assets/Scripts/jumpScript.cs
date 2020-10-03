using UnityEngine;

public class jumpScript : MonoBehaviour
{
  private bool isJumping;
  private float _jumpTimeCounter;

  public void Jump (bool grounded, bool isButtonDown, float jumpForce, float jumpTime, Rigidbody2D rb)
  {
    if (grounded)
    {
      isJumping = true;
      _jumpTimeCounter = jumpTime;
    }

    if (isJumping && isButtonDown)
    {
      if (_jumpTimeCounter > 0)
      {
        rb.velocity = Vector2.up * jumpForce;
        _jumpTimeCounter -= Time.deltaTime;
      }
      else
        isJumping = false;
    }

    if (!isButtonDown)
      isJumping = false;
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
