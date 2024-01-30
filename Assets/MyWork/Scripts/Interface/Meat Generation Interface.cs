public interface IMeatGenerator
{
    public float MeatProductionSpeed { set; }
    public int MeatAmount { get; set; }
    public void StartMeatGeneration(bool startGeneration);
}