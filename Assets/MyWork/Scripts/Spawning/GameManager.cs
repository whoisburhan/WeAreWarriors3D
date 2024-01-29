using System;
using UnityEngine;
using WeAreFighters3D.Data;
using WeAreFighters3D.MeatSystem;
using WeAreFighters3D.Spwaner;

public class GameManager : MonoBehaviour
{
    private IUnitSpawner[] spawner;
    private IMeatGenerator meatGenerator;

    private BattleUnitTireData playerUnitTireData;
    private BattleUnitTireData enemyUnitTireData;

    private void Awake()
    {
        spawner = GetComponentsInChildren<IUnitSpawner>();
        meatGenerator = GetComponent<IMeatGenerator>();
    }

    public void StartGame() 
    {
        if(spawner != null) 
        {
            playerUnitTireData = GameData.OnGetCurretTireUnitsRequest(PlayerType.Player);
            spawner[0].TiresAllUnitData = playerUnitTireData;
            spawner[0].ActivateSpawn();

            enemyUnitTireData = GameData.OnGetCurretTireUnitsRequest(PlayerType.Enemy);
            spawner[1].TiresAllUnitData = enemyUnitTireData;
            spawner[1].ActivateSpawn();
        }

        if(meatGenerator != null) 
        {
            meatGenerator.MeatProductionSpeed = GameData.OnGetMeatProductionSpeedRequest();
            meatGenerator.StartMeatGeneration(true);
        }
    }

    public void SpawnPlayerUnitReq(int batleUnitIndex) 
    {
        int cost = playerUnitTireData.UnitTireData[batleUnitIndex].UnitGenerationCost;

        if (meatGenerator.MeatAmount >= cost) 
        {
            spawner[0].SpawnUnit(batleUnitIndex);
            meatGenerator.MeatAmount -= cost;
        }
    }

    
}
