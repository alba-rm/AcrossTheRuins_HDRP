using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    private SaveSystem saveSystem;

    private void Start()
    {
        saveSystem = FindObjectOfType<SaveSystem>();
    }

    public void ContinueGame()
    {
        GameData data = saveSystem.LoadGame();
        if (data != null)
        {
            SceneManager.LoadScene(data.sceneName);
            StartCoroutine(SetPlayerPosition(data.playerPosX, data.playerPosY, data.playerPosZ));
        }
        else
        {
            // No save data, start a new game or handle appropriately
            NewGame();
        }
    }

    private IEnumerator SetPlayerPosition(float x, float y, float z)
    {
        yield return new WaitForSeconds(0.1f); // Optionally wait for the scene to load
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.transform.position = new Vector3(x, y, z);
        }
    }

    public void NewGame()
    {
        // Load the first scene of your game
        SceneManager.LoadScene("FirstScene");
    }
}