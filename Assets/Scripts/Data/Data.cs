using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class Data
{
    static string dataSavePath = Application.persistentDataPath + "/GameData.dat";

    public static void SaveData(GameData data)
    {
        BinaryFormatter formatter = new();
        FileStream dataFile = new (dataSavePath, FileMode.Create);
        formatter.Serialize(dataFile, data);
        dataFile.Close();
    }
    public static GameData LoadData()
    {
        if (File.Exists(dataSavePath))
        {
            BinaryFormatter formatter = new();
            FileStream dataFile = new (dataSavePath, FileMode.Open);
            GameData result = formatter.Deserialize(dataFile) as GameData;
            dataFile.Close();
            return result;
        }
        else
            return null;
    }
}

[System.Serializable]
public class GameData
{
    public int CurrentLevel;
    public int CurrentCurrencyAmount;
    public string CurrentProjectile;

    public GameData(string projectile)
    { 
        CurrentLevel = 1;
        CurrentCurrencyAmount = 0;
        CurrentProjectile = projectile;
    }
}
