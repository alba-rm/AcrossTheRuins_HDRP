using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionZone : MonoBehaviour
{
    private TPSController playerController;

    void Start()
    {
        playerController = GameObject.FindWithTag("Player").GetComponent<TPSController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactuable"))
        {
            playerController.SetObjectToGrab(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactuable"))
        {
            playerController.SetObjectToGrab(null);
        }
    }
}