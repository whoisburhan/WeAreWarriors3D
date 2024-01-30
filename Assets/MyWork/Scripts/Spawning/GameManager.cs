using System;
using UnityEngine;
using UnityEngine.Events;
using WeAreFighters3D.Data;
using WeAreFighters3D.MeatSystem;
using WeAreFighters3D.Spwaner;

public class GameManager : MonoBehaviour
{
    public static Action OnGameEnd;
    public static Action<int> OnUpdateMatchCoinCollection;

    public UnityEvent OnGameEndUIUpdate;
    public UnityEvent<string> OnMatchCoinUpdate;

    private IUnitSpawner[] spawner;
    private IMeatGenerator meatGenerator;
    private IBaseController[] baseController;

    private BattleUnitTireData playerUnitTireData;
    private BattleUnitTireData enemyUnitTireData;

    private int matchCointCollected;


    private void Awake()
    {
        spawner = GetComponentsInChildren<IUnitSpawner>();
        meatGenerator = GetComponent<IMeatGenerator>();
        baseController = GetComponentsInChildren<IBaseController>();
    }

    private void OnEnable()
    {
        OnGameEnd += OnGameEndUIUpdateFunc;
        OnUpdateMatchCoinCollection += UpdateInMatchCoinCollection;
    }
    private void OnDisable()
    { 
        OnGameEnd -= OnGameEndUIUpdateFunc;
        OnUpdateMatchCoinCollection -= UpdateInMatchCoinCollection;
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

        if(baseController != null) 
        {
            baseController[0].BaseHealth = GameData.OnGetBaseHealthDataRequest();

            // Enemy Base Health Data Not Implemented Yet :( For Now Set a deafault 500 HP
            baseController[1].BaseHealth = 500; // Test
        }

        matchCointCollected = 0;
        OnMatchCoinUpdate?.Invoke(matchCointCollected.ToString());
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

    private void OnGameEndUIUpdateFunc() 
    {
        OnGameEndUIUpdate?.Invoke();
    }

    private void UpdateInMatchCoinCollection(int rewardCoin)
    {
        matchCointCollected += rewardCoin;
        OnMatchCoinUpdate?.Invoke(matchCointCollected.ToString());
    }
}
