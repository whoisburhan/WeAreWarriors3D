using UnityEngine;

[CreateAssetMenu(fileName ="Battle Unit",menuName = "BattleUnit")]
public class BattleUnitData : ScriptableObject
{
    public float Speed;
    public int MaxHealth;
    public float RadarRange;
    public int Attack;
}
