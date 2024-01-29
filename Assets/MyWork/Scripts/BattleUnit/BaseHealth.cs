using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace WeAreFighters3D.BattleUnit
{
    public class BaseHealth : MonoBehaviour, IHealthUI
    {
        [SerializeField] private Image healthIndicator;
        [SerializeField] private TextMeshProUGUI healthAmountText;

        private int maxHealth = 5;
        public int MaxHealth
        {
            set
            {
                maxHealth = value;
                Reset();
            }
        }

        public void UpdateHealthInUI(int currentHealth)
        {
            if (healthIndicator != null) healthIndicator.fillAmount = (float)currentHealth / (float)maxHealth;
            if (healthAmountText != null) healthAmountText.text = currentHealth.ToString();
        }

        public void Reset()
        {
            if (healthIndicator != null) UpdateHealthInUI(maxHealth);
            if (healthAmountText != null) healthAmountText.text = maxHealth.ToString();
        }
    }
}