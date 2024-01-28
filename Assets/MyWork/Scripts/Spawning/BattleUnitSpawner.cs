using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeAreFighters3D.Spwaner
{
    public class BattleUnitSpawner : MonoBehaviour, IUnitSpawner
    {
        protected TireEvolutionData tireEvolutionData;

        public TireEvolutionData TireEvolutionData { set => tireEvolutionData = value; }

        public void ActivateSpawn()
        {
            
        }


    }

    public interface IUnitSpawner
    {
        public TireEvolutionData TireEvolutionData { set; }
        public void ActivateSpawn();
    }
}