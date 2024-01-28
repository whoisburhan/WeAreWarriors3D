using UnityEngine;
using WeAreFighters3D.BattleUnit;

namespace WeAreFighters3D.Spwaner
{
    public class PlayerUnitSpawner : BattleUnitSpawner
    {
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space)) 
            {
                SpawnPlayerUnit(0);
            }
        }
        public void SpawnPlayerUnit(int spawnIndex)
        {
            if(spawnIndex >= tiresAllUnitData.UnitTireData.Count)
            {
                Debug.LogError($"Spawn Index Out Of Range. Check it again!!!");
                return;
            }

            var data = tiresAllUnitData.UnitTireData[spawnIndex];
            var go = ObjectPoolManager.SpawnObject(data.UnitPrefab, transform.position, transform.rotation);
            
            var unitController = go.GetComponent<IBattleUnitController>();
            unitController.UpdateData(data.UnitData, moveDir, oponentLayer);
        }
    }
}