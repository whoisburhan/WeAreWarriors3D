using WeAreFighters3D.Data;

public interface IGameRowData
{
    public SaveState State { get; set; }
    public void Save();
    public void Load();
}