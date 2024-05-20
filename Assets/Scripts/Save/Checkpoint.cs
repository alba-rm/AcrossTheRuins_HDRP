using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public int checkpointID;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SaveGameAtCheckpoint();
        }
    }

    private void SaveGameAtCheckpoint()
    {
    GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Vector3 playerPosition = player.transform.position;
            int currentSceneIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
            PlayerData data = new PlayerData(playerPosition, currentSceneIndex, checkpointID);
            SaveSystem.SaveGame(data);
        }
        else
        {
            Debug.LogError("No se encontró el jugador para guardar su posición.");
        }
    }
}