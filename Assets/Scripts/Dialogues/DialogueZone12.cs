using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueZone12 : MonoBehaviour
{
    public UIManagerCasas uiManager;
    public Julien julienScript;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiManager.ToggleDialogueUI(1, true);
            
            if (julienScript != null)
            {
                julienScript.SetTalkingAnimation(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiManager.ToggleDialogueUI(1, false);
            
            if (julienScript != null)
            {
                julienScript.SetTalkingAnimation(false);
            }
        }
    }
}