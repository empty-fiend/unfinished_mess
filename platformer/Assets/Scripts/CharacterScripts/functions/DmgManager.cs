using UnityEngine;

namespace CharacterScripts.functions
{
  public class DmgManager : MonoBehaviour
  {
    public void DealtDamage(Collider2D col, int health, int dealDamage)
    {
      bool touched = Physics2D.IsTouching(GetComponent<Collider2D>(), col);
    }
  }
}
