using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Evolution", menuName = "Data/Evolution Data")]
public class TireEvolutionData : ScriptableObject
{
    public List<TireData> TireData;
}

[Serializable]
public class TireData 
{
    public BattleUnitTireData BattleUnitTireData;
    public int EvolutionCost;
}
