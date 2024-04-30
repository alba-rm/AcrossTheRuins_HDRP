using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject generalUI;
    public GameObject dialogueUI;
    
    void Start()
    {
        generalUI.SetActive(true);
        dialogueUI.SetActive(false);
    }

    public void ToggleDialogueUI(bool showDialogue)
    {
        generalUI.SetActive(!showDialogue);
        dialogueUI.SetActive(showDialogue);
    }
}