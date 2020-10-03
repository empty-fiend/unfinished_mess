using UnityEngine;

public class raycastScript : MonoBehaviour
{
  private RaycastHit2D _rayhit;

  public bool IsISeePlayer (Transform playerCheck, LayerMask whoIsYourEnemy, float distance, bool movingRight)
  {
    _rayhit = Physics2D.Raycast(playerCheck.position, movingRight ? Vector2.right : Vector2.left, distance, whoIsYourEnemy);

    return _rayhit.collider;
  }

  public bool IsISeeGround (float distance, Transform groundDetection, LayerMask whatIsGround)
  {
    _rayhit = Physics2D.Raycast(groundDetection.position, Vector2.down, distance, whatIsGround);

    return _rayhit.collider;
  }
}
