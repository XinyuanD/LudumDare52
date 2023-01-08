using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public PlayerController player;
    public Dialogue[] conversations = new Dialogue[4];

    private void Start()
    {
        DisableDialogueBox();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (player.hasKey)
            {
                dialogueManager.gameObject.SetActive(true);
                dialogueManager.OpenDialogue(conversations[0]);
                player.hasKey = false;
            }
            else if (player.hasLetter)
            {
                dialogueManager.gameObject.SetActive(true);
                dialogueManager.OpenDialogue(conversations[1]);
                player.hasLetter = false;
            }
            else if (player.hasDrugs)
            {
                dialogueManager.gameObject.SetActive(true);
                dialogueManager.OpenDialogue(conversations[2]);
                player.hasDrugs = false;
            }
            else if (player.hasDagger)
            {
                dialogueManager.gameObject.SetActive(true);
                dialogueManager.OpenDialogue(conversations[3]);
                player.hasDagger = false;
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
