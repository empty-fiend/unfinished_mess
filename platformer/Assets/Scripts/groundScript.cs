using UnityEngine;

public class groundScript : MonoBehaviour
{

  public bool Grounded(Collider2D _collider2D,LayerMask whatIsGround)
  {
    return Physics2D.IsTouchingLayers(_collider2D, whatIsGround);
  }
}
