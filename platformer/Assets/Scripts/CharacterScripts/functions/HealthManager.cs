using UnityEngine;
using UnityEngine.UI;

namespace CharacterScripts.functions
{
    public class HealthManager : MonoBehaviour
    {
        public Image[] hearts;
        public Sprite fullHeart, emptyHeart;

        public void Health(int health, int numOfHearts)
        {
            if (health > numOfHearts)
                health = numOfHearts;
            for (var i = 0; i < hearts.Length; i++)
            {
                hearts[i].sprite = i < health ? fullHeart : emptyHeart;
                hearts[i].enabled = i < numOfHearts;
            }
        }

        public void Health()
        {
            
        }
    }
}
