using UnityEngine;

namespace WeAreFighters3D.BattleUnit
{
    public class BattleUnitController : MonoBehaviour
    {
        // Controller for each battle unit

        /// Health
        private IHealth health;
        

        /// Attack
        /// Movement

        private IMovement movement;

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

        /// Animation
        /// Radar
        /// HealthUI
    }


   

    public interface IHealth
    {
        public int MaxHealth { set; }

        /// <returns>Alive 1 or Death 0</returns>
        public bool GotDamage(int damageAmount);
        public void Reset();
    }


    /// <summary>
    ///---------------------------------------------------------------------------------------------------
    /// </summary>

    public interface IMovement
    {
        public float Speed { set; }
        public void Move(MoveDir moveDireaction);
    }

    // public interface Health
}