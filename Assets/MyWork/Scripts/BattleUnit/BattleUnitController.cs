using UnityEngine;

namespace WeAreFighters3D.BattleUnit
{
    public class BattleUnitController : MonoBehaviour, IBattleUnitController
    {
        //[SerializeField] BattleUnitData data;
        //[SerializeField] private LayerMask mask;
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

        private void Start()
        {
            //UpdateData(data, MoveDir.Right, mask);
        }

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

        private void Damage(int damageAmount) 
        {
            var currentHealth = health.GotDamage(damageAmount);
            healthUI.UpdateHealthInUI(currentHealth);

            if(currentHealth <= 0) 
            {
                ObjectPoolManager.ReturnObjectToPool(this.gameObject);
            }
        }
    }
}