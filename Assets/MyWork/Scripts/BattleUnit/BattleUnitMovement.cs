using UnityEngine;

namespace WeAreFighters3D.BattleUnit
{
    public enum MoveDir 
    {
        Stop = 0, Left = -1, Right = 1
    }

    [RequireComponent(typeof(Rigidbody), typeof(Collider))]
    public class BattleUnitMovement : MonoBehaviour, IMovement
    {
        private Rigidbody rb; 
        private float speed = 5f;
        [SerializeField]private MoveDir dir;

        public float Speed { set => speed = value;  }
        public MoveDir MoveDir { set => dir = value; }

        private void Awake() => rb = GetComponent<Rigidbody>();

        public void Move()
        {
            Vector3 position = transform.position;

            position.x += speed * (float)dir * Time.deltaTime;
            rb.MovePosition(position);
        }
    }
}