using UnityEngine;
using WeAreFighters3D.BattleUnit;

namespace WeAreFighters3D.Spwaner
{
    public class EnemyUnitSpawner : BattleUnitSpawner
    {
        private const int ENEMY_LAYER = 7; //Test

        [SerializeField] private float spawnIntervalTime = 10f;
        float timer = 0;
        bool canSpawn = false;

        private void OnEnable() => GameManager.OnGameEnd += Reset;
        private void OnDisable() => GameManager.OnGameEnd -= Reset;

        private void Update()
        {
            if (canSpawn) 
            {
                timer -= Time.deltaTime;
                
                if(timer <= 0 ) 
                {
                    SpawnUnit(Random.Range(0, tiresAllUnitData.UnitTireData.Count)); // Test
                    timer = spawnIntervalTime;
                }
            }

        }
        public override void SpawnUnit(int spawnIndex)
        {
            if (spawnIndex >= tiresAllUnitData.UnitTireData.Count)
            {
                Debug.LogError($"Spawn Index Out Of Range. Check it again!!!");
                return;
            }

            var data = tiresAllUnitData.UnitTireData[spawnIndex];
            var go = ObjectPoolManager.SpawnObject(data.UnitPrefab, transform.position, transform.rotation,PoolType.Particles);
            go.layer = ENEMY_LAYER;
            var unitController = go.GetComponent<IBattleUnitController>();
            unitController.UpdateData(data.UnitData, moveDir, oponentLayer);
        }

        public override void ActivateSpawn()
        {
            canSpawn = true;
            timer = spawnIntervalTime;
        }

        private void Reset()
        {
            canSpawn = false;
        }
    }
}