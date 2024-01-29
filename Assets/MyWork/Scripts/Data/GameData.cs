using System;
using UnityEngine;

namespace WeAreFighters3D.Data
{
    public class GameData : MonoBehaviour
    {
        public static Func<float> OnGetMeatProductionSpeedRequest;
        public static Func<PlayerType, BattleUnitTireData> OnGetCurretTireUnitsRequest;

        public static Action<BattleUnitTireData, int> OnUpdateTireData;

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

        private void Start()
        {
            UpdateTire();
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

            return tireEvolutionData.TireData[evolutionIndex].BattleUnitTireData;
        }

        private void UpdateTire()
        {
            var unitTireData = tireEvolutionData.TireData[gameRowData.State.EvolutionIndex];
            OnUpdateTireData?.Invoke(unitTireData.BattleUnitTireData, gameRowData.State.CurrentTireUnlockedBattleUnitIndex);
        }
    }

    public enum PlayerType 
    {
        Player, Enemy
    }



}