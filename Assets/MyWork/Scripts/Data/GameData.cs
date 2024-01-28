using System;
using UnityEngine;

namespace WeAreFighters3D.Data
{
    public class GameData : MonoBehaviour
    {
        public static Func<float> OnGetMeatProductionSpeedRequest;
        public static Func<PlayerType, BattleUnitTireData> OnGetCurretTireUnitsRequest;

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
            OnGetCurretTireUnitsRequest += GetTireEvolutionData;
        }
        private void OnDisable()
        {
            OnGetMeatProductionSpeedRequest -= GetMeatProductionSpeed;
            OnGetCurretTireUnitsRequest -= GetTireEvolutionData;
        }

        private float GetMeatProductionSpeed()
        {
            int productionSpeedIndex = gameRowData.State.MeatGeneratorIndex;
            productionSpeedIndex = Mathf.Clamp(productionSpeedIndex, 0, meatData.meatData.Count - 1);
            return meatData.meatData[productionSpeedIndex].MeatGeneratePerSecond;
        }

        //private BattleUnitTireData GetCurrentTireUnits() 
        //{
        //    int currentActiveTireIndex = gameRowData.State.EvolutionIndex;
        //    currentActiveTireIndex = Mathf.Clamp(currentActiveTireIndex, 0, tireEvolutionData.TireData.Count - 1);
        //    return tireEvolutionData.TireData[currentActiveTireIndex].BattleUnitTireData;
        //}

        public  BattleUnitTireData GetTireEvolutionData(PlayerType playerType) 
        {
            int evolutionIndex = playerType == PlayerType.Player ? gameRowData.State.EvolutionIndex : gameRowData.State.EnemyEvolutionIndex;
            
            if (evolutionIndex >= tireEvolutionData.TireData.Count) 
            {
                Debug.LogError("Index Out OF Bounce!!! Check it");
                return null;
            }

            Debug.Log("AAAAAA " + tireEvolutionData.TireData[evolutionIndex].BattleUnitTireData.name);
            return tireEvolutionData.TireData[evolutionIndex].BattleUnitTireData;
        }

    }

    public enum PlayerType 
    {
        Player, Enemy
    }



}