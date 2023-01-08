using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public Dialogue[] conversations = new Dialogue[4];

    private void Start()
    {
        DisableDialogueBox();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (PlayerController.hasKey)
            {
                dialogueManager.gameObject.SetActive(true);
                dialogueManager.OpenDialogue(conversations[0]);
                PlayerController.hasKey = false;
            }
            else if (PlayerController.hasLetter)
            {
                dialogueManager.gameObject.SetActive(true);
                dialogueManager.OpenDialogue(conversations[1]);
                PlayerController.hasLetter = false;
            }
            else if (PlayerController.hasDrugs)
            {
                dialogueManager.gameObject.SetActive(true);
                dialogueManager.OpenDialogue(conversations[2]);
                PlayerController.hasDrugs = false;
            }
            else if (PlayerController.hasDagger)
            {
                dialogueManager.gameObject.SetActive(true);
                dialogueManager.OpenDialogue(conversations[3]);
                PlayerController.hasDagger = false;
            }
            else
            {
                return;
            }
        }
    }

    public void DisableDialogueBox()
    {
        dialogueManager.gameObject.SetActive(false);
    }
}
