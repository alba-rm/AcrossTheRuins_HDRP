using UnityEngine;
using System.IO;

public static class SaveSystem
{
    private static string savePath = Application.persistentDataPath + "/savefile.json";

    public static void SaveGame(PlayerData data)
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(savePath, json);
    }

    public static PlayerData LoadGame()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);
            return data;
        }
        else
        {
            return null;
        }
    }

    public static void DeleteSave()
    {
        if (File.Exists(savePath))
        {
            File.Delete(savePath);
        }
    }
}