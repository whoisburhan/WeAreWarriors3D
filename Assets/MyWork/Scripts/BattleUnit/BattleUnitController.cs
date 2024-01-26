using UnityEngine;
using UnityEngine.UI;

namespace WeAreFighters3D.BattleUnit
{
    public class BattleUnitController : MonoBehaviour
    {
        // Controller for each battle unit

        /// Movement
        private IMovement movement;
        /// Health
        private IHealth health;
        /// HealthUI
        private IHealthUI healthUI;
        /// Radar
        /// Attack
        /// Animation


        private void Awake()
        {
            if (movement == null) movement = GetComponent<IMovement>();
            if (health == null) health = GetComponent<IHealth>();
            if (healthUI == null) healthUI = GetComponent<IHealthUI>();
        }

        private void Update()
        {
            movement.Speed = 1.5f;
            movement.Move(MoveDir.Left);
        }

    }

   

    //---------------------------------------------------------------------------------------------------

    public interface IReset 
    {
        public void Reset();
    }

    public interface IMovement
    {
        public float Speed { set; }
        public void Move(MoveDir moveDireaction);
    }
    public interface IHealth : IReset
    {
        public int MaxHealth { set; }

        public float GotDamage(int damageAmount);
        
    }

    public interface IHealthUI : IReset
    {
        public int MaxHealth { set; }
        public void UpdateHealthInUI(int currentHealth);
    }
}