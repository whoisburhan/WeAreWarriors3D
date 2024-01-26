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
        private IRadar radar;
        /// Attack
        /// Animation


        private void Awake()
        {
            if (movement == null) movement = GetComponent<IMovement>();
            if (health == null) health = GetComponent<IHealth>();
            if (healthUI == null) healthUI = GetComponent<IHealthUI>();
            if (radar == null) radar = GetComponent<IRadar>();
        }

        private void Update()
        {
            var detectObj = radar.DetectOponentUnit();
            if(detectObj == null) 
            {
                // Movement
            }
            else 
            {
                //Attack
            }
            movement.Speed = 1.5f;
            movement.Move(MoveDir.Left);
        }

    }

    public class BattleUnitAttack : MonoBehaviour, IAttack
    {
        private int damageDealAmount = 2;
        public int DamageDealAmount { set => damageDealAmount = value; }

        public void Attack()
        {
            // Attack Enemy
        }
    }

    internal interface IAttack
    {
        public int DamageDealAmount { set; }
        public void Attack();
    }

    public interface IRadar
    {
        public float RadarRange { set; }
        public LayerMask DetectableObjLayerMask { set; }
        public Transform DetectOponentUnit();
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