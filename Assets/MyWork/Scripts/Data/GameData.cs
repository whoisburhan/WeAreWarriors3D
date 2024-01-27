using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace WeAreFighters3D.Data
{
    [System.Serializable]
    public class SaveState
    {
        public int MeatGeneratorIndex;
        public int BaseHealthIndex;
        public int EvolutionIndex;
        public int CurrentTireUnlockedBattleUnitIndex;

    }

    public class GameData : MonoBehaviour
    {
        public static GameData Instance { get; private set; }
        public SaveState State { get => state; set => state = value; }

        [Header("Logic")]

        [SerializeField] public string SaveFileName = "data.TG";
        private string saveFileName;
        [SerializeField] private bool loadOnStart = true;

        private SaveState state;
        private BinaryFormatter formatter;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this);
            }
        }

        private void Start()
        {
            state = new SaveState();
            saveFileName = Application.persistentDataPath + "/" + SaveFileName;
            Debug.Log(saveFileName);
            formatter = new BinaryFormatter();
            Load();
        }

        public void Save()
        {
            //If there no previous state loaded, create a new one
            if (State == null)
            {
                State = new SaveState();
            }

            var file = new FileStream(saveFileName, FileMode.OpenOrCreate, FileAccess.Write);
            formatter.Serialize(file, State);
            file.Close();
        }

        public void Load()
        {
            // Open a physical file, on your disk to hold the save


            try
            {
                // If we found the file, open and read it
                var file = new FileStream(saveFileName, FileMode.Open, FileAccess.Read);
                State = (SaveState)formatter.Deserialize(file);
                file.Close();

            }
            catch
            {
                Debug.Log("No file found, creating new entry...");
                ///UIManager.Instance.FirstTimeGameOn = true;
                Save();
            }
        }


       

    }
}