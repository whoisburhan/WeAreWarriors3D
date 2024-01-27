using UnityEngine;
using WeAreFighters3D.Data;

namespace WeAreFighters3D.MeatSystem
{
    public class MeatGenerator : MonoBehaviour, IMeatGenerator
    {
        [SerializeField] MeatGeneratorData meatData;

        [SerializeField]
        private int currentMeatAmount = 0;
        private float timer = 0;
        private float meatProductionSpeed;
        bool startGeneration = true;
        public float MeatProductionSpeed { set => meatProductionSpeed = value; }

        private void Start()
        {
            StartMeatGeneration();
        }

        private void Update()
        {
            if(startGeneration) GenerateMeat();
        }

        private void GenerateMeat() 
        {
            if(timer <= 0) 
            {
                currentMeatAmount++;
                timer = MeatGeneratorFormula(meatProductionSpeed);
            }
            timer -= Time.deltaTime;
            //Debug.Log(timer);
        }

        public void StartMeatGeneration() 
        {
            meatProductionSpeed = GameData.OnGetMeatProductionSpeedRequest();
            Debug.Log(meatProductionSpeed);
            timer = MeatGeneratorFormula(meatProductionSpeed);
            startGeneration = true;
        }

        private float MeatGeneratorFormula(float meatPerSecond) =>  1 / meatPerSecond;
    }

    public interface IMeatGenerator
    {
        public float MeatProductionSpeed { set; }

    }
}