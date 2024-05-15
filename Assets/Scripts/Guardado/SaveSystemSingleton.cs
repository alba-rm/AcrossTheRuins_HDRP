using UnityEngine;

public class SaveSystemSingleton : MonoBehaviour
{
    public static SaveSystemSingleton instance;
    private SaveSystem saveSystem;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            saveSystem = GetComponent<SaveSystem>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveGame(string sceneName, Vector3 playerPosition)
    {
        saveSystem.SaveGame(sceneName, playerPosition);
    }

    public GameData LoadGame()
    {
        return saveSystem.LoadGame();
    }
}