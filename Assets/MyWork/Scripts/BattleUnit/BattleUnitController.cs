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
        /// Animation <summary>
        private IAnimation battleUnitAnimation;
        /// </summary>
        // Will Implement Later

        BattleUnitAnimationState currentState;
        Transform detectObj = null;
        int rewardAmount;
        Collider unitCollider;
        Rigidbody rb;

        private void Awake() => Init();

        private void OnEnable()
        {
            GameManager.OnGameEnd += AutoDeActivate;
            detectObj = null;
            unitCollider.enabled = true;
        }
        private void OnDisable() => GameManager.OnGameEnd -= AutoDeActivate;

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
            if(battleUnitAnimation == null) battleUnitAnimation = GetComponent<IAnimation>();
            if(unitCollider == null) unitCollider = GetComponent<Collider>();
            if(rb == null) rb = GetComponent<Rigidbody>();
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

            rewardAmount = data.MaxHealth; // Test , For Now Let's reward based on the maxHealth
            currentState = BattleUnitAnimationState.Walk;
        }

        private void BattleUnitEngine() 
        {
            detectObj = radar.DetectOponentUnit();

            if (currentState != BattleUnitAnimationState.Die)
            {
                if (detectObj == null)
                {
                    movement.Move();
                    currentState = BattleUnitAnimationState.Walk;
                    battleUnitAnimation.SetAnimationState(currentState);
                }
                else
                {
                    if (currentState != BattleUnitAnimationState.Attack)
                    {
                        currentState = BattleUnitAnimationState.Attack;
                        battleUnitAnimation.SetAnimationState(currentState);
                    }
                }
            }
        }

        private void Damage(int damageAmount) 
        {
            Debug.Log("Damage");
            var currentHealth = health.GotDamage(damageAmount);
            healthUI.UpdateHealthInUI(currentHealth);

            if(currentHealth <= 0) 
            {
                currentState = BattleUnitAnimationState.Die;
                battleUnitAnimation.SetAnimationState(currentState);
            }
        }

        // This will call by animation Event
        public void Attack() 
        {
            unitAttack.Attack(detectObj);
        }

        public void Die() 
        {
            if (gameObject.layer == 7) GameManager.OnUpdateMatchCoinCollection?.Invoke(rewardAmount);
            gameObject.layer = 0;
            rb.isKinematic = false;
            //AutoDeActivate();
        }

        public void AutoDeActivate() 
        {
            ObjectPoolManager.ReturnObjectToPool(gameObject, PoolType.BattleUnit);
        }
    }

    
}