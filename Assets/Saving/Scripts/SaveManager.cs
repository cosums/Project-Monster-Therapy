using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class SaveManager : MonoBehaviour
{
    [Header("PLAYTESTING ONLY! LEAVE BLANK WHEN FINAL BUILD!!!")]
    public SaveDataAsset debugStartData;

    private string Root => Application.persistentDataPath + "/";
    public string SaveFileName = "save_data.quirstn";

    public SaveData CurrentSave { get; private set; }

    void Start()
    {
        SaveData data;

        if (debugStartData != null)
        {
            CurrentSave = debugStartData.ToSaveData();
        }  
        else
        {
            CurrentSave = LoadGame();
            if (CurrentSave == null)
            {
                CurrentSave = new SaveData
                {
                    // setup defaults here
                    uuid = System.Guid.NewGuid().ToString() 
                };
            }
        }
    } 

    public void SaveGame(SaveData data)
    {
       string path = Path.Combine(Root, SaveFileName);
       
       string json = JsonConvert.SerializeObject(data, Formatting.Indented);
       File.WriteAllText(path, json);
    }

    public SaveData LoadGame()
    {
        string path = Path.Combine(Root, SaveFileName);
        if (!File.Exists(path)) return null;

        string json = File.ReadAllText(path);
        return JsonConvert.DeserializeObject<SaveData>(json);
    }
}
