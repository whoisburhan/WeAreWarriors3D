using UnityEngine;
using WeAreFighters3D.BattleUnit;

namespace WeAreFighters3D.Spwaner
{
    public class EnemyUnitSpawner : BattleUnitSpawner
    {
        private const int ENEMY_LAYER = 7; //Test

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                //SpawnPlayerUnit(0);
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
    }
}