using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Save1 : MonoBehaviour
{
    public static Save1 instance;

    [SerializeField] private Vector3 defaultPlayerPosition;

    private GameObject playerJac;
    private string currentCheckpoint = "";

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        playerJac = GameObject.Find("PlayerJac");

        LoadData();
    }

    public void SaveData(string checkpointID)
    {
        currentCheckpoint = checkpointID;
        string sceneName = SceneManager.GetActiveScene().name;

        if (playerJac != null)
        {
            PlayerPrefs.SetFloat(sceneName + "_Jac_position_x", playerJac.transform.position.x);
            PlayerPrefs.SetFloat(sceneName + "_Jac_position_y", playerJac.transform.position.y);
            PlayerPrefs.SetFloat(sceneName + "_Jac_position_z", playerJac.transform.position.z);
        }

        PlayerPrefs.SetString(sceneName + "_checkpoint", checkpointID);
        PlayerPrefs.Save();
    }

    void LoadData()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        
            if (PlayerPrefs.HasKey(sceneName + "_Jac_position_x"))
            {
                Vector3 savedPosition = new Vector3(
                    PlayerPrefs.GetFloat(sceneName + "_Jac_position_x"),
                    PlayerPrefs.GetFloat(sceneName + "_Jac_position_y"),
                    PlayerPrefs.GetFloat(sceneName + "_Jac_position_z")
                );
                if (playerJac != null)
                {
                    playerJac.transform.position = savedPosition;
                }
            }
        
        else
        {
            if (playerJac != null)
            {
                playerJac.transform.position = defaultPlayerPosition;
            }
        }
    }

    public void DeleteData()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        PlayerPrefs.DeleteKey(sceneName + "_checkpoint");
        PlayerPrefs.DeleteKey(sceneName + "_Jac_position_x");
        PlayerPrefs.DeleteKey(sceneName + "_Jac_position_y");
        PlayerPrefs.DeleteKey(sceneName + "_Jac_position_z");

        PlayerPrefs.Save();

        LoadData();
    }
}
