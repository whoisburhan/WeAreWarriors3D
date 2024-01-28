using UnityEngine;
using WeAreFighters3D.BattleUnit;

namespace WeAreFighters3D.Spwaner
{
    public class PlayerUnitSpawner : BattleUnitSpawner
    {
        public void SpawnPlayerUnit(int spawnIndex)
        {
            if(spawnIndex >= tiresAllUnitData.UnitTireData.Count)
            {
                Debug.LogError($"Spawn Index Out Of Range. Check it again!!!");
                return;
            }

            var data = tiresAllUnitData.UnitTireData[spawnIndex];
            var go = ObjectPoolManager.SpawnObject(data.UnitPrefab, transform.position, Quaternion.identity);
            
            var unitController = go.GetComponent<IBattleUnitController>();
            unitController.UpdateData(data.UnitData, moveDir, oponentLayer);
        }
    }
}