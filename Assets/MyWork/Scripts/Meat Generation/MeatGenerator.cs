using UnityEngine;

namespace WeAreFighters3D.MeatSystem
{
    public class MeatGenerator : MonoBehaviour, IMeatGenerator
    {
        [SerializeField] MeatGeneratorData meatData;

        private float meatProductionSpeed;
        public float MeatProductionSpeed { set => meatProductionSpeed = value; }

        private void Update()
        {
            
        }

        private void GenerateMeat() 
        {

        }

        private float MeatGeneratorFormula(float meatPerSecond) =>  1 / meatPerSecond;
    }

    public interface IMeatGenerator
    {
        public float MeatProductionSpeed { set; }

    }
}