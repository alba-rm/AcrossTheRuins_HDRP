using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Save : MonoBehaviour
{
    [SerializeField] private Vector3 defaultPlayerPosition;
    [SerializeField] private Vector3 defaultIA1Position;

    private GameObject player;
    private GameObject ia1;
    public Transform[] players;

    public static Save instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        player = GameObject.Find("PlayerNathalie");
        ia1 = GameObject.Find("PlayerJac");

        LoadData();
    }

    public void SaveData(string checkpointID)
    {
        string sceneName = SceneManager.GetActiveScene().name;

        PlayerPrefs.SetFloat(sceneName + "_Nathalie_position_X", player.transform.position.x);
        PlayerPrefs.SetFloat(sceneName + "_Nathalie_position_Y", player.transform.position.y);
        PlayerPrefs.SetFloat(sceneName + "_Nathalie_position_Z", player.transform.position.z);

        PlayerPrefs.SetFloat(sceneName + "_Jac_position_X", ia1.transform.position.x);
        PlayerPrefs.SetFloat(sceneName + "_Jac_position_Y", ia1.transform.position.y);
        PlayerPrefs.SetFloat(sceneName + "_Jac_position_Z", ia1.transform.position.z);

        PlayerPrefs.Save();
    }

    public void LoadData()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        if (PlayerPrefs.HasKey(sceneName + "_Nathalie_position_X"))
        {
            float x = PlayerPrefs.GetFloat(sceneName + "_Nathalie_position_X");
            float y = PlayerPrefs.GetFloat(sceneName + "_Nathalie_position_Y");
            float z = PlayerPrefs.GetFloat(sceneName + "_Nathalie_position_Z");
            player.transform.position = new Vector3(x, y, z);
        }
        else
        {
            player.transform.position = defaultPlayerPosition;
        }

        if (PlayerPrefs.HasKey(sceneName + "_Jac_position_X"))
        {
            float x = PlayerPrefs.GetFloat(sceneName + "_Jac_position_X");
            float y = PlayerPrefs.GetFloat(sceneName + "_Jac_position_Y");
            float z = PlayerPrefs.GetFloat(sceneName + "_Jac_position_Z");
            ia1.transform.position = new Vector3(x, y, z);
        }
        else
        {
            ia1.transform.position = defaultIA1Position;
        }
    }

    public void DeleteData()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        PlayerPrefs.DeleteKey(sceneName + "_Nathalie_position_X");
        PlayerPrefs.DeleteKey(sceneName + "_Nathalie_position_Y");
        PlayerPrefs.DeleteKey(sceneName + "_Nathalie_position_Z");

        PlayerPrefs.DeleteKey(sceneName + "_Jac_position_X");
        PlayerPrefs.DeleteKey(sceneName + "_Jac_position_Y");
        PlayerPrefs.DeleteKey(sceneName + "_Jac_position_Z");

        PlayerPrefs.Save();

        LoadData();
    }
}
