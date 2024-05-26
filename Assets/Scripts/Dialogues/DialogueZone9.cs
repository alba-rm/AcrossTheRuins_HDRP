using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueZone9 : MonoBehaviour
{
    public UIManagerCalle2 uiManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiManager.ToggleDialogueUI(0, true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiManager.ToggleDialogueUI(0, false);
        }
    }
}