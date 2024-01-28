using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using WeAreFighters3D.Spwaner;

public class GameManager : MonoBehaviour
{
    private IUnitSpawner[] spawner;

    private void Awake()
    {
        spawner = GetComponentsInChildren<IUnitSpawner>();
    }

    public void StartGame() 
    {
        if(spawner == null) 
        {
            spawner[0].TiresAllUnitData = null;
            spawner[0].ActivateSpawn();

            spawner[1].TiresAllUnitData= null;
            spawner[1].ActivateSpawn();
        }
    }

}
