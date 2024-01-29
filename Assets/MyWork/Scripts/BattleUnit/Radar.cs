using UnityEngine;

namespace WeAreFighters3D.BattleUnit
{
    public class Radar : MonoBehaviour, IRadar
    {
        private float radarRange = 10f;
        [SerializeField] private LayerMask layerMask;
        public float RadarRange { set => radarRange = value; }
        public LayerMask DetectableObjLayerMask { set => layerMask = value; }

        public Transform DetectOponentUnit()
        {
            RaycastHit hit;
            if(Physics.BoxCast(transform.position, transform.lossyScale / 2, transform.forward, out hit, Quaternion.identity, radarRange, layerMask)) 
            {
                Debug.Log($"ENEME " + hit.transform.name);
                return hit.transform;
            }
            return null;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube((transform.position + transform.forward * radarRange)/2,
                new Vector3(radarRange, transform.lossyScale.y, transform.lossyScale.z));
        }

    }
}