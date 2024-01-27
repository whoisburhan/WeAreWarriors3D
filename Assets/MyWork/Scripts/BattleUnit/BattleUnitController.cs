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


        private void Awake() => Init();
        private void Update() => BattleUnitEngine();

        private void Init() 
        {
            if (movement == null) movement = GetComponent<IMovement>();
            if (health == null) health = GetComponent<IHealth>();
            if (healthUI == null) healthUI = GetComponent<IHealthUI>();
            if (radar == null) radar = GetComponent<IRadar>();
            if (unitAttack == null) unitAttack = GetComponent<IAttack>();
        }
        public void UpdateData(BattleUnitData data, MoveDir moveDir, LayerMask oponentLayer)
        {
            movement.Speed = data.Speed;
            movement.MoveDir = moveDir;
            health.MaxHealth = data.MaxHealth;
            healthUI.MaxHealth = data.MaxHealth;
            radar.RadarRange = data.RadarRange;
            radar.DetectableObjLayerMask = oponentLayer;
            unitAttack.DamageDealAmount = data.Attack;
        }

        private void BattleUnitEngine() 
        {
            var detectObj = radar.DetectOponentUnit();

            if (detectObj == null) movement.Move();
            else unitAttack.Attack(detectObj);
        }

    }

    public enum BattleUnitAnimationState
    {
        Idle, Chase
    }
    public class BattleUnitAnimation : MonoBehaviour, IAnimation 
    {
       
    }

    internal interface IAnimation
    {
    }

    //---------------------------------------------------------------------------------------------------

    public interface IReset 
    {
        public void Reset();
    }

    public interface IMovement
    {
        public float Speed { set; }
        public MoveDir MoveDir { set; }
        public void Move();
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