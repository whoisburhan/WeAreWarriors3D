using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Base Health Data", menuName = "Data/Base Health Data")]
public class BaseHealthData : ScriptableObject
{
    public List<BaseHealth> healthData;
}

[Serializable]
public class BaseHealth
{
    public int MaxHealth;
    public int UpgradePrice;
}