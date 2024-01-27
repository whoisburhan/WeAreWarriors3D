using System;
using UnityEngine;

namespace WeAreFighters3D.Data
{
    public class GameData : MonoBehaviour
    {
        public static Func<float> OnGetMeatProductionSpeedRequest;
        public static Func<BattleUnitTireData> OnGetCurretTireUnitsRequest;

        private IGameRowData gameRowData;

        [SerializeField] MeatGeneratorData meatData;
        [SerializeField] BaseHealthData baseHealthData;
        [SerializeField] TireEvolutionData tireEvolutionData;

        private void Awake()
        {
            gameRowData = GetComponent<IGameRowData>();
        }

        private void OnEnable()
        {
            OnGetMeatProductionSpeedRequest += GetMeatProductionSpeed;
            OnGetCurretTireUnitsRequest += GetCurrentTireUnits;
        }
        private void OnDisable()
        {
            OnGetMeatProductionSpeedRequest -= GetMeatProductionSpeed;
            OnGetCurretTireUnitsRequest -= GetCurrentTireUnits;
        }

        private float GetMeatProductionSpeed() 
        {
            int productionSpeedIndex = gameRowData.State.MeatGeneratorIndex;
            productionSpeedIndex = Mathf.Clamp(productionSpeedIndex, 0, meatData.meatData.Count - 1);
            return meatData.meatData[productionSpeedIndex].MeatGeneratePerSecond;
        }

        private BattleUnitTireData GetCurrentTireUnits() 
        {
            int currentActiveTireIndex = gameRowData.State.EvolutionIndex;
            currentActiveTireIndex = Mathf.Clamp(currentActiveTireIndex, 0, tireEvolutionData.TireData.Count - 1);
            return tireEvolutionData.TireData[currentActiveTireIndex].BattleUnitData;
        }


    }

    
}