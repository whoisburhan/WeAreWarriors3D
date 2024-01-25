using UnityEngine;

namespace WeAreFighters3D.BattleUnit
{
    public class BattleUnitController : MonoBehaviour
    {
        // Controller for each battle unit

        /// Health
        /// Attack
        /// Movement

        [SerializeField] IMovement movement;

        private void Awake()
        {
            if (movement == null) movement = GetComponent<IMovement>();
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


    

    public interface IMovement
    {
        public float Speed { set; }
        public void Move(MoveDir moveDireaction);
    }

    // public interface Health
}