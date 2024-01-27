using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace WeAreFighters3D.Data
{


    public class GameData : MonoBehaviour
    {
        public static Func<float> OnGetMeatProductionSpeedRequest;

        private IGameRowData gameRowData;

        [SerializeField] MeatGeneratorData meatData;

        private void Awake()
        {
            gameRowData = GetComponent<IGameRowData>();
        }

        private void OnEnable()
        {
            OnGetMeatProductionSpeedRequest += GetMeatProductionSpeed;
        }
        private void OnDisable()
        {
            OnGetMeatProductionSpeedRequest -= GetMeatProductionSpeed;
        }

        public float GetMeatProductionSpeed() 
        {
            int productionSpeedIndex = gameRowData.State.MeatGeneratorIndex;

            Debug.Log($"productionSpeedIndex {productionSpeedIndex} : meatData.meatData[productionSpeedIndex].MeatGeneratePerSecond  {meatData.meatData[productionSpeedIndex].MeatGeneratePerSecond}");

            return productionSpeedIndex < meatData.meatData.Count ? meatData.meatData[productionSpeedIndex].MeatGeneratePerSecond 
                : meatData.meatData[meatData.meatData.Count-1].MeatGeneratePerSecond;
        }


    }

    
}