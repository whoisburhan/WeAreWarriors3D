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

        public void ActivateSpawn()
        {

        }


    }

    public interface IUnitSpawner
    {
        public BattleUnitTireData TiresAllUnitData { set; }
        public void ActivateSpawn();
    }
}