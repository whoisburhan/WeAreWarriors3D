using UnityEngine;

public class Example : MonoBehaviour
{
    // The center of the box
    public Vector3 m_Center = Vector3.zero;
    // The size of the box
    public Vector3 m_Size = new Vector3(0.5f, 0.5f, 0.5f);
    // The direction of the box
    public Vector3 m_Direction = Vector3.forward;
    // The angle of the box
    public float m_Angle = 0.0f;
    // The maximum distance of the box
    public float m_MaxDistance = 10.0f;
    // The color of the box
    public Color m_Color = Color.red;

    void Update()
    {
        // Cast the box and store the result
        RaycastHit hit;
        bool isHit = Physics.BoxCast(m_Center, m_Size / 2, m_Direction, out hit, Quaternion.Euler(0, m_Angle, 0), m_MaxDistance);

        // If the box hits something, output a message
        if (isHit)
        {
            Debug.Log("Hit " + hit.collider.name);
        }

        
    }

    private void OnDrawGizmos()
    {
        // Draw the box as a gizmo to show where it is currently testing
        Gizmos.color = m_Color;
        Gizmos.matrix = Matrix4x4.TRS(m_Center, Quaternion.Euler(0, m_Angle, 0), m_Size);
        Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
    }
}
