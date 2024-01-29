using UnityEngine;

namespace WeAreFighters3D.BattleUnit
{
    public class Health : MonoBehaviour, IHealth
    {
        private int maxHealth = 5;
        private int currentHealth;

        public int MaxHealth 
        {
            set
            {
                maxHealth = value;
                Reset();
            }
        }

        public int GotDamage(int damageAmount)
        {
            currentHealth -= damageAmount;

            return currentHealth;
        }

        public void Reset() => currentHealth = maxHealth;
    }
}