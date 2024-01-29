using UnityEngine;

[CreateAssetMenu(fileName ="Battle Unit",menuName = "Data/Battle Unit")]
public class BattleUnitData : ScriptableObject
{
    public float Speed;
    public int MaxHealth;
    public float RadarRange;
    public int Attack;
    public int UnitGenerationCost;
}
