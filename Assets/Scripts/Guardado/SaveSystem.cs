using UnityEngine;
using System.IO;

public class SaveSystem : MonoBehaviour
{
    public void SaveGame(string sceneName, Vector3 playerPosition)
    {
        GameData data = new GameData();
        data.sceneName = sceneName;
        data.playerPosX = playerPosition.x;
        data.playerPosY = playerPosition.y;
        data.playerPosZ = playerPosition.z;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public GameData LoadGame()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            GameData data = JsonUtility.FromJson<GameData>(json);
            return data;
        }
        return null;
    }
}