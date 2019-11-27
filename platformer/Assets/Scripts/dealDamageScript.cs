using UnityEngine;

public class dealDamageScript : MonoBehaviour
{
  public void dealtDamage(Collider2D col, int health, int dealDamage)
  {
    bool touched = Physics2D.IsTouching(GetComponent<Collider2D>(), col);
    if (touched)
    {
      health -= dealDamage;
    }
  }
}
