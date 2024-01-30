using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeAreFighters3D.BattleUnit;

namespace WeAreFighters3D.Spwaner
{
    public class BattleUnitSpawner : MonoBehaviour, IUnitSpawner
    {
        [SerializeField] protected MoveDir moveDir;
        [SerializeField] protected LayerMask oponentLayer;

        protected BattleUnitTireData tiresAllUnitData;

        public BattleUnitTireData TiresAllUnitData { set => tiresAllUnitData = value; }

        public virtual void ActivateSpawn() { }

        public virtual void SpawnUnit(int spawnIndex) { }
    }

    public interface IUnitSpawner
    {
        public BattleUnitTireData TiresAllUnitData { set; }
        public void ActivateSpawn();

        public void SpawnUnit(int spawnIndex);
    }
}