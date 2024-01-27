using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit Tire", menuName = "Data/Unit Tire Data")]
public class BattleUnitTireData : ScriptableObject
{
    public List<UnitTire> UnitTireData;
}

[Serializable]
public class UnitTire 
{
    public string UnitName;
    public int UnitUnlockPrice;
    public Sprite UnitPortrait;
    public GameObject UnitPrefab;
}