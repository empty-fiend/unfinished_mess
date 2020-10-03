using UnityEngine;

public class moveScript : MonoBehaviour
{
  public bool _movingRight;

  public void Moving (float speed, bool isShooting)
  {
    if (_movingRight)
    {
        transform.eulerAngles = new Vector3(0, -180, 0);
        _movingRight = false;
    }
    else if (!_movingRight)
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
        _movingRight = true;
    }
    if (!isShooting)
      transform.Translate(Time.deltaTime * speed * Vector2.right);
  }

  public void Moving (float move, bool isRunning, float walkSpeed, float runSpeed, Rigidbody2D rb, Transform otherTransform)
  {
      if (move < 0 && _movingRight)
      {
          otherTransform.eulerAngles = new Vector3(0, -180, 0);
          _movingRight = false;
      }
      else if (move > 0 && !_movingRight)
      {
          otherTransform.eulerAngles = new Vector3(0, 0, 0);
          _movingRight = true;
      }

      var speed = !isRunning ? walkSpeed : runSpeed;

      rb.velocity = new Vector2(move * speed, rb.velocity.y);
  }
}
