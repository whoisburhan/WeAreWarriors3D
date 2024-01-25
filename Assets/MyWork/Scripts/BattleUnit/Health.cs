using UnityEngine;

namespace WeAreFighters3D.BattleUnit
{
    public class Health : MonoBehaviour, IHealth
    {
        private int maxHealth = 5;
        private int currentHealth;

        public int MaxHealth { set => maxHealth = value; }

        public float GotDamage(int damageAmount)
        {
            currentHealth -= damageAmount;

            return (float) currentHealth / (float) maxHealth; // return true if alive , false if dead
        }

        public void Reset() => currentHealth = maxHealth;
    }
}