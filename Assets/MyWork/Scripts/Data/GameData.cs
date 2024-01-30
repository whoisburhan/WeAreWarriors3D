using System;
using UnityEngine;
using UnityEngine.Events;

namespace WeAreFighters3D.Data
{
    public class GameData : MonoBehaviour
    {
        public static Func<float> OnGetMeatProductionSpeedRequest;
        public static Func<PlayerType, BattleUnitTireData> OnGetCurretTireUnitsRequest;
        public static Func<int> OnGetBaseHealthDataRequest;
        public static Func<int> OnGetTotalCoin;

        public static Action<BattleUnitTireData, int> OnUpdateTireData;
        public static Action<int> OnUpdateTotalCoin;
        public static Action<MeatData> OnUpdatNextMeatProductionSpeed;
        public static Action<BaseHealth> OnUpdateNextBaseHp;
        public static Action OnIncreaseMeatGeneartionSpeedIndex;
        public static Action OnIncreaseBaseHpIndex;

        public UnityEvent<string> OnUpdateCoinInString;

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
            OnGetBaseHealthDataRequest += GetBaseHealth;
            OnGetTotalCoin += GetTotalCoin;
            OnUpdateTotalCoin += UpdateTotalCoin;
            OnIncreaseMeatGeneartionSpeedIndex += IncreaseMeatGenerationSpeedIndex;
            OnIncreaseBaseHpIndex += IncreaseBaseHPIndex;
        }
        private void OnDisable()
        {
            OnGetMeatProductionSpeedRequest -= GetMeatProductionSpeed;
            OnGetCurretTireUnitsRequest -= GetTireEvolutionData;
            OnGetBaseHealthDataRequest -= GetBaseHealth;
            OnGetTotalCoin -= GetTotalCoin;
            OnUpdateTotalCoin -= UpdateTotalCoin;
            OnIncreaseMeatGeneartionSpeedIndex -= IncreaseMeatGenerationSpeedIndex;
            OnIncreaseBaseHpIndex -= IncreaseBaseHPIndex;
        }

        private void Start()
        {
            UpdateTire();
            UpdateUI();
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

        private int GetBaseHealth() => baseHealthData.healthData[gameRowData.State.BaseHealthIndex].MaxHealth;

        private void UpdateTotalCoin(int amount)
        {
            Debug.Log($"UpdateTotalCoin(int amount) {amount}");
            gameRowData.State.CoinAmount += amount;
            if(gameRowData.State.CoinAmount < 0) gameRowData.State.CoinAmount = 0;

            UpdateUI();

            gameRowData.Save();
        }

        private int GetTotalCoin() => gameRowData.State.CoinAmount;

        private void IncreaseMeatGenerationSpeedIndex() 
        {
            gameRowData.State.MeatGeneratorIndex++;
            //gameRowData.Save();
        }

        private void IncreaseBaseHPIndex() 
        {
            gameRowData.State.BaseHealthIndex++;
            //gameRowData.Save();
        }

        private void UpdateUI() 
        {
            OnUpdateCoinInString?.Invoke(CoinInTextForm.CoinInText(gameRowData.State.CoinAmount));

            int nextMeatProductionSpeedIndex = gameRowData.State.MeatGeneratorIndex + 1;

            if(nextMeatProductionSpeedIndex < meatData.meatData.Count) 
            {
                OnUpdatNextMeatProductionSpeed?.Invoke(meatData.meatData[nextMeatProductionSpeedIndex]);
            }
            int nextBaseHpIndex = gameRowData.State.BaseHealthIndex + 1;

            if(nextBaseHpIndex < baseHealthData.healthData.Count) 
            {
                OnUpdateNextBaseHp?.Invoke(baseHealthData.healthData[nextBaseHpIndex]);
            }
         
        }
    }

    public enum PlayerType 
    {
        Player, Enemy
    }



}