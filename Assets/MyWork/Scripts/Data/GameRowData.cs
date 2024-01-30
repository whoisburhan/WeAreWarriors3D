using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace WeAreFighters3D.Data
{
    public class GameRowData : MonoBehaviour, IGameRowData
    {
        public SaveState State { get => state; set => state = value; }

        const string SaveFileName = "data.TG";
        private string saveFileName;

        private SaveState state;
        private BinaryFormatter formatter;

        private void Awake()
        {
            state = new SaveState();
            saveFileName = Application.persistentDataPath + "/" + SaveFileName;
            Debug.Log(saveFileName);
            formatter = new BinaryFormatter();
            Load();
        }

        public void Save()
        {
            if (State == null) State = new SaveState();

            var file = new FileStream(saveFileName, FileMode.OpenOrCreate, FileAccess.Write);
            formatter.Serialize(file, State);
            file.Close();
        }

        public void Load()
        {
            try
            {
                var file = new FileStream(saveFileName, FileMode.Open, FileAccess.Read);
                State = (SaveState)formatter.Deserialize(file);
                file.Close();
            }
            catch
            {
                Debug.Log("No file found, creating new entry...");
                Save();
            }
        }
    }
}