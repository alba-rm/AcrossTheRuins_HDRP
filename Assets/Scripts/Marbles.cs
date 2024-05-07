using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Marbles : MonoBehaviour
{
    public Text marblesCountText;
    private int marblesCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            marblesCount++;
            UpdateMarblesCountText();
        }
    }

    void UpdateMarblesCountText()
    {
        if (marblesCountText != null)
        {
            marblesCountText.text = "Canicas: " + marblesCount.ToString(); 
        }
    }

    public void SaveMarblesCount()
    {
        PlayerPrefs.SetInt("MarblesCount", marblesCount);
        PlayerPrefs.Save();
    }
    
    public void LoadMarblesCount()
    {
        if (PlayerPrefs.HasKey("MarblesCount"))
        {
            marblesCount = PlayerPrefs.GetInt("MarblesCount");
            UpdateMarblesCountText();
        }
    }

    private void OnApplicationQuit()
    {
        SaveMarblesCount();
    }

    private void OnDestroy()
    {
        SaveMarblesCount();
    }
}