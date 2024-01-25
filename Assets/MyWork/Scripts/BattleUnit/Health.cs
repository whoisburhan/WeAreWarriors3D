using UnityEngine;

namespace WeAreFighters3D.BattleUnit
{
    public class Health : MonoBehaviour, IHealth
    {
        private int maxHealth = 5;
        private int currentHealth;

        public int MaxHealth { set => maxHealth = value; }

        public bool GotDamage(int damageAmount)
        {
            currentHealth -= damageAmount;

            return currentHealth > 0; // return true if alive , false if dead
        }

        public void Reset() => currentHealth = maxHealth;
    }
}