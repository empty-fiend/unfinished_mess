using UnityEngine;

namespace CharacterScripts.functions
{
  public class CollideManager : MonoBehaviour
  {

    public bool IsIGrounded(Collider2D objectCollider,LayerMask groundLayers)
    {
      return Physics2D.IsTouchingLayers(objectCollider, groundLayers);
    }

    public bool IsISeePlayer (Transform playerCheck, LayerMask enemyLayers, float distance, bool movingRight)
    {
      return Physics2D.Raycast(playerCheck.position, movingRight ? Vector2.right : Vector2.left, distance, enemyLayers);
    }

    public bool IsISeeGround (float distance, Transform groundDetection, LayerMask groundLayers)
    {
      return Physics2D.Raycast(groundDetection.position, Vector2.down, distance, groundLayers);
    }
  }
}
