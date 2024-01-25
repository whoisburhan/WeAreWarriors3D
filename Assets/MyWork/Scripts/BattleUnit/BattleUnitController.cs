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
        /// Radar
        /// Attack
        /// Animation


        private void Awake()
        {
            if (movement == null) movement = GetComponent<IMovement>();
            if (health == null) health = GetComponent<IHealth>();
        }

        void FixedUpdate()
        {
            movement.Speed = 1.5f;
            movement.Move(MoveDir.Left);
        }

        public void UpdateHealthInUI(float currentHealthPercetnage) 
        {

        }

    }


    //---------------------------------------------------------------------------------------------------

    public interface IMovement
    {
        public float Speed { set; }
        public void Move(MoveDir moveDireaction);
    }
    public interface IHealth
    {
        public int MaxHealth { set; }

        public float GotDamage(int damageAmount);
        public void Reset();
    }
}