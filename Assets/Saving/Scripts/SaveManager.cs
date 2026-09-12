using UnityEngine;
using System.IO;
//using Newtonsoft.Json;

public class SaveManager : MonoBehaviour
{
    [Header("PLAYTESTING ONLY! LEAVE BLANK WHEN FINAL BUILD!!!")]
    public SaveDataAsset debugStartData;

    private string Root => Application.persistentDataPath + "/";

    void Start()
    {
        SaveData data;

        if (debugStartData != null)
        {
            data = debugStartData.ToSaveData();
        }  
        else
        {
            data = LoadGame();
            if (data == null)
            {
                data = new SaveData
                {
                    // setup defaults here
                    uuid = System.Guid.NewGuid().ToString() 
                };
            }
        }
    } 

    public void SaveGame(SaveData save)
    {
       //string json = JsonConvert
    }

    public SaveData LoadGame()
    {
        return null;
    }
}
