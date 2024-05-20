using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Guarda el juego aquí
        SaveGameAtSceneChange();
    }

    public void SaveGameAtSceneChange()
    {
        // Supongamos que tienes una referencia al jugador
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Vector3 playerPosition = player.transform.position;
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int checkpointID = 0; // Sustituir con el método adecuado para obtener el ID del checkpoint
            PlayerData data = new PlayerData(playerPosition, currentSceneIndex, checkpointID);
            SaveSystem.SaveGame(data);
        }
        else
        {
            Debug.LogError("No se encontró el jugador para guardar su posición.");
        }
    }
}