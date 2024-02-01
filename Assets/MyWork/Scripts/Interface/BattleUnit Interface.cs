using UnityEngine;

namespace WeAreFighters3D.BattleUnit 
{
    public interface IBattleUnitController
    {
        public void UpdateData(BattleUnitData data, MoveDir moveDir, LayerMask oponentLayer);
    }

    public enum BattleUnitAnimationState
    {
        Walk, Attack, Die
    }

    internal interface IAnimation
    {
        public void SetAnimationState(BattleUnitAnimationState state);
    }

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

        public int GotDamage(int damageAmount);

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