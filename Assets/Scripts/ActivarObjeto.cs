using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarObjeto : MonoBehaviour
{
    public GameObject objetoAActivar;
    public GameObject objetoACoger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            objetoAActivar.SetActive(true);
        }
    }

    public void CogerObjeto()
    {
        objetoACoger.SetActive(false);
    }
}
