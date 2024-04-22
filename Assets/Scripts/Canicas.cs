using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canicas : MonoBehaviour
{
     private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TPSController player = other.GetComponent<TPSController>();
            if (player != null)
            {
                player.CollectMarble();
                Destroy(gameObject);
            }
        }
    }
}
