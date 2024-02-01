using UnityEngine;

namespace WeAreFighters3D.BattleUnit
{
    public class BattleUnitAttack : MonoBehaviour, IAttack
    {
        private int damageDealAmount = 2;
        private float attackTimeInterval = 2f;
        float interval = 0f;
        public int DamageDealAmount { set => damageDealAmount = value; }
        public float AttackTimeInterval { set => attackTimeInterval = value; }

        public void Attack(Transform targetEnemy)
        {
            if(targetEnemy == null) return;
            targetEnemy.SendMessage("Damage", damageDealAmount);
        }
    }
}