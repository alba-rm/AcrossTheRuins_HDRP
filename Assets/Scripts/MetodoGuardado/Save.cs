using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Save : MonoBehaviour
{
    public static Save instance;

    [SerializeField] public string checkPoint;
    [SerializeField] public Vector3 playerPosition;
    [SerializeField] private float _positionX;
    [SerializeField] private float _positionY;
    [SerializeField] private float _positionZ;

    private GameObject playerNathalie;
    private GameObject playerJac;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // No destruir el objeto al cambiar de escena
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        playerNathalie = GameObject.Find("PlayerNathalie");
        playerJac = GameObject.Find("PlayerJac");

        LoadData();
    }

    void Start()
    {
        if (playerNathalie != null)
        {
            playerNathalie.transform.position = playerPosition;
        }
        if (playerJac != null)
        {
            playerJac.transform.position = playerPosition;
        }
    }

    public void SaveData()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        if (playerNathalie != null)
        {
            PlayerPrefs.SetFloat(sceneName + "Nathalie_position_x", playerNathalie.transform.position.x);
            PlayerPrefs.SetFloat(sceneName + "Nathalie_position_y", playerNathalie.transform.position.y);
            PlayerPrefs.SetFloat(sceneName + "Nathalie_position_z", playerNathalie.transform.position.z);
        }
        if (playerJac != null)
        {
            PlayerPrefs.SetFloat(sceneName + "Jac_position_x", playerJac.transform.position.x);
            PlayerPrefs.SetFloat(sceneName + "Jac_position_y", playerJac.transform.position.y);
            PlayerPrefs.SetFloat(sceneName + "Jac_position_z", playerJac.transform.position.z);
        }

        PlayerPrefs.Save();
    }

    void LoadData()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        if (PlayerPrefs.HasKey(sceneName + "Nathalie_position_x"))
        {
            playerPosition = new Vector3(
                PlayerPrefs.GetFloat(sceneName + "Nathalie_position_x"),
                PlayerPrefs.GetFloat(sceneName + "Nathalie_position_y"),
                PlayerPrefs.GetFloat(sceneName + "Nathalie_position_z")
            );
            if (playerNathalie != null)
            {
                playerNathalie.transform.position = playerPosition;
            }
        }
        if (PlayerPrefs.HasKey(sceneName + "Jac_position_x"))
        {
            playerPosition = new Vector3(
                PlayerPrefs.GetFloat(sceneName + "Jac_position_x"),
                PlayerPrefs.GetFloat(sceneName + "Jac_position_y"),
                PlayerPrefs.GetFloat(sceneName + "Jac_position_z")
            );
            if (playerJac != null)
            {
                playerJac.transform.position = playerPosition;
            }
        }
    }

    public void DeleteData()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        PlayerPrefs.DeleteKey(sceneName + "Nathalie_position_x");
        PlayerPrefs.DeleteKey(sceneName + "Nathalie_position_y");
        PlayerPrefs.DeleteKey(sceneName + "Nathalie_position_z");
        PlayerPrefs.DeleteKey(sceneName + "Jac_position_x");
        PlayerPrefs.DeleteKey(sceneName + "Jac_position_y");
        PlayerPrefs.DeleteKey(sceneName + "Jac_position_z");

        PlayerPrefs.Save();

        LoadData();
    }
}