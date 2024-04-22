using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text canicasCountText;
    public TPSController tpsController;

    public void UpdateMarbleCount(int count)
    {
        canicasCountText.text = "Canicas: " + count.ToString();
    }

    public void OnDistractEnemiesButtonClicked()
    {
        tpsController.UseMarbleToDistractEnemies();
    }
}
