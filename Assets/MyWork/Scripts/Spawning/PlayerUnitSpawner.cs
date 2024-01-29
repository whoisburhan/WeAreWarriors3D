using UnityEngine;
using WeAreFighters3D.BattleUnit;

namespace WeAreFighters3D.Spwaner
{
    public class PlayerUnitSpawner : BattleUnitSpawner
    {
        private const int PLAYER_LAYER = 6;  // Test
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space)) 
            {
                //SpawnPlayerUnit(0);
            }

        }
        public override void SpawnUnit(int spawnIndex)
        {
            if(spawnIndex >= tiresAllUnitData.UnitTireData.Count)
            {
                Debug.LogError($"Spawn Index Out Of Range. Check it again!!!");
                return;
            }

            var data = tiresAllUnitData.UnitTireData[spawnIndex];
            var go = ObjectPoolManager.SpawnObject(data.UnitPrefab, transform.position, transform.rotation, PoolType.BattleUnit);
            go.layer = PLAYER_LAYER;
            var unitController = go.GetComponent<IBattleUnitController>();
            unitController.UpdateData(data.UnitData, moveDir, oponentLayer);
        }
    }
}