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
            if (PlayerController.hasItems[0])
            {
                dialogueManager.gameObject.SetActive(true);
                dialogueManager.OpenDialogue(conversations[0]);
                PlayerController.hasItems[0] = false;
            }
            else if (PlayerController.hasItems[1])
            {
                dialogueManager.gameObject.SetActive(true);
                dialogueManager.OpenDialogue(conversations[1]);
                PlayerController.hasItems[1] = false;
            }
            else if (PlayerController.hasItems[2])
            {
                dialogueManager.gameObject.SetActive(true);
                dialogueManager.OpenDialogue(conversations[2]);
                PlayerController.hasItems[2] = false;
            }
            else if (PlayerController.hasItems[3])
            {
                dialogueManager.gameObject.SetActive(true);
                dialogueManager.OpenDialogue(conversations[3]);
                PlayerController.hasItems[3] = false;
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
