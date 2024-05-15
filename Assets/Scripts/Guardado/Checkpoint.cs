using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private SaveSystem saveSystem;

    private void Start()
    {
        saveSystem = FindObjectOfType<SaveSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            saveSystem.SaveGame(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name, other.transform.position);
        }
    }
}