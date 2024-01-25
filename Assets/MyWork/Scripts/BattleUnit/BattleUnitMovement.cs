using UnityEngine;

namespace WeAreFighters3D.BattleUnit
{
    public enum MoveDir 
    {
        Idle = 0, Left = -1, Right = 1
    }

    [RequireComponent(typeof(Rigidbody), typeof(Collider))]
    public class BattleUnitMovement : MonoBehaviour, IMovement
    {
        private Rigidbody rb; 
        private float speed = 5f;

        public float Speed { set => speed = value;  }

        private void Awake() => rb = GetComponent<Rigidbody>();

        public void Move(MoveDir moveDirection)
        {
            Vector3 position = transform.position;

            position.x += speed * (float)moveDirection * Time.deltaTime;

            rb.MovePosition(position);
        }
    }
}