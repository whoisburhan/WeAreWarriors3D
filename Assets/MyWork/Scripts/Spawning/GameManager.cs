using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using WeAreFighters3D.Data;
using WeAreFighters3D.Spwaner;

public class GameManager : MonoBehaviour
{
    private IUnitSpawner[] spawner;

    private void Awake()
    {
        spawner = GetComponentsInChildren<IUnitSpawner>();
    }

    private void Start()
    {
        StartGame();
    }

    public void StartGame() 
    {
        if(spawner != null) 
        {
            spawner[0].TiresAllUnitData = GameData.OnGetCurretTireUnitsRequest(PlayerType.Player);
            spawner[0].ActivateSpawn();

            spawner[1].TiresAllUnitData = GameData.OnGetCurretTireUnitsRequest(PlayerType.Enemy);
            spawner[1].ActivateSpawn();
        }
    }

}
