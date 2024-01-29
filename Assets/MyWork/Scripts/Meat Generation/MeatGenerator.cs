using UnityEngine;
using UnityEngine.Events;
using WeAreFighters3D.Data;

namespace WeAreFighters3D.MeatSystem
{
    public class MeatGenerator : MonoBehaviour, IMeatGenerator
    {
        [SerializeField] UnityEvent<float> MeatGenerationProgress;
        [SerializeField] UnityEvent<string> UpdateMeatAmountEvent;

        private int currentMeatAmount = 0;
        private float timer = 0;
        private float meatProductionSpeed;
        bool startGeneration = true;
        public float MeatProductionSpeed { set => meatProductionSpeed = value; }
        public int MeatAmount 
        { 
            get => currentMeatAmount;
            set
            {
                currentMeatAmount = value;
                UpdateMeatAmountEvent.Invoke(value.ToString());
            } 
        }

        private void Start()
        {
           // StartMeatGeneration();
        }

        public void StartMeatGeneration(bool startGeneration) 
        {
            meatProductionSpeed = MeatGeneratorFormula(meatProductionSpeed);
            this.startGeneration = startGeneration;
        }

        private void Update()
        {
            if(startGeneration) GenerateMeat();
        }

        private void GenerateMeat() 
        {
            if(timer >= meatProductionSpeed) 
            {
                currentMeatAmount++;
                UpdateMeatAmountEvent.Invoke(currentMeatAmount.ToString());
                timer = 0;
                
            }
            MeatGenerationProgress.Invoke(timer*(1/meatProductionSpeed));
            //m_MeatGenerationProgress.fillAmount = 
            timer += Time.deltaTime;
            //Debug.Log(timer);
        }

        public void StartMeatGeneration() 
        {
            //meatProductionSpeed = GameData.OnGetMeatProductionSpeedRequest();
            Debug.Log(meatProductionSpeed);
            timer = MeatGeneratorFormula(meatProductionSpeed);
            startGeneration = true;
        }

        private float MeatGeneratorFormula(float meatPerSecond) =>  1 / meatPerSecond;
    }

    public interface IMeatGenerator
    {
        public float MeatProductionSpeed { set; }
        public int MeatAmount { get;set; }
        public void StartMeatGeneration(bool startGeneration);
    }
}