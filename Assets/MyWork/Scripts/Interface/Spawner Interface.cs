public interface IUnitSpawner
{
    public BattleUnitTireData TiresAllUnitData { set; }
    public void ActivateSpawn();

    public void SpawnUnit(int spawnIndex);
}