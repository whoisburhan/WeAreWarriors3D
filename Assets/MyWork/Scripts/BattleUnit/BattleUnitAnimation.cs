using UnityEngine;

namespace WeAreFighters3D.BattleUnit
{
    [RequireComponent(typeof(Animator))]
    public class BattleUnitAnimation : MonoBehaviour, IAnimation
    {
        private Animator animator;

        private int walk = Animator.StringToHash("Walk");
        private int attack = Animator.StringToHash("Attack");
        private int die = Animator.StringToHash("Die");

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void SetAnimationState(BattleUnitAnimationState state)
        {
            switch (state)
            {
                case BattleUnitAnimationState.Walk:
                    animator.Play(walk);
                    break;
                case BattleUnitAnimationState.Attack:
                    animator.Play(attack);
                    break;
                case BattleUnitAnimationState.Die:
                    animator.Play(die);
                    break;
            }
        }
    }
}