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
        private IAttack unitAttack;
        /// Animation


        private void Awake()
        {
            if (movement == null) movement = GetComponent<IMovement>();
            if (health == null) health = GetComponent<IHealth>();
            if (healthUI == null) healthUI = GetComponent<IHealthUI>();
            if (radar == null) radar = GetComponent<IRadar>();
            if (unitAttack == null) unitAttack = GetComponent<IAttack>();
        }

        public void Init(BattleUnitData data)
        {
            movement.Speed = data.Speed;
            health.MaxHealth = data.MaxHealth;
            healthUI.MaxHealth = data.MaxHealth;
            radar.RadarRange = data.RadarRange;
            unitAttack.DamageDealAmount = data.Attack;
        }

        private void Update()
        {
            var detectObj = radar.DetectOponentUnit();
            if(detectObj == null) 
            {
                // Movement
                movement.Move(MoveDir.Left);
            }
            else 
            {
                //Attack
                unitAttack.Attack(detectObj);
            }

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

    public interface IRadar
    {
        public float RadarRange { set; }
        public LayerMask DetectableObjLayerMask { set; }
        public Transform DetectOponentUnit();
    }

    public interface IAttack
    {
        public int DamageDealAmount { set; }
        public float AttackTimeInterval { set; }
        public void Attack(Transform targetEnemy);
    }
}