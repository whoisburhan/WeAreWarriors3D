using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Meat Generator Data",menuName = "Data/Meat Generator Data")]
public class MeatGeneratorData : ScriptableObject
{
    public List<MeatData> meatData;
}

[Serializable]
public class MeatData 
{
    public float MeatGeneratePerSecond;
    public int UpgradePrice;
}
