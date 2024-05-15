using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorMarbles : MonoBehaviour
{
    public static ControladorMarbles Instance;
    [SerializeField] private float cantidadMarbles;

    private void Awake()
    {
        if (ControladorMarbles.Instance == null)
        {
            ControladorMarbles.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SumarMarbles(float marbles)
    {
        cantidadMarbles += marbles;
    }
}