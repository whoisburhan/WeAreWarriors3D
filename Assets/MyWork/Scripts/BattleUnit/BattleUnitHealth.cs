using UnityEngine;
using UnityEngine.UI;

namespace WeAreFighters3D.BattleUnit
{
    public class BattleUnitHealth : MonoBehaviour, IHealthUI
    {
        [SerializeField] private Image healthIndicator;

        private int maxHealth = 5;
        public int MaxHealth
        {
            set
            {
                maxHealth = value;
                healthIndicator.gameObject.SetActive(true);
                Reset();
            }
        }

        public void UpdateHealthInUI(int currentHealth)
        {
            if (healthIndicator != null) healthIndicator.fillAmount = (float)currentHealth / (float)maxHealth;
            if(currentHealth  <= 0) healthIndicator.gameObject.SetActive(false);
        }

        public void Reset()
        {
            if (healthIndicator != null) UpdateHealthInUI(maxHealth);
        }
    }
}