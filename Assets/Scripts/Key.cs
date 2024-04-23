using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject KeyObject;
    public GameObject Level;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Level.gameObject.SetActive(true);
            Destroy(KeyObject);
        }
    }
}
