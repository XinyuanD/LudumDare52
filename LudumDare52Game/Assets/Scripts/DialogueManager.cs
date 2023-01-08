using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    //public DialogueTrigger trigger;
    public NPC npcs;
    public Image actorImage;
    public TextMeshProUGUI actorName;
    public TextMeshProUGUI messageText;

    private Message[] currentMessages;
    private Actor[] currentActors;
    int activeMessage = 0;
    public static bool isDialogueActive = false;

    public void OpenDialogue(Dialogue dialogue)
    {
        currentMessages = dialogue.messages;
        currentActors = dialogue.actors;
        activeMessage = 0;
        isDialogueActive = true;
        Debug.Log("Started conversation! Messages Loaded: " + dialogue.messages.Length);
        DisplayMessage();
    }

    //public void OpenDialogue(Message[] messages, Actor[] actors)
    //{
    //    currentMessages = messages;
    //    currentActors = actors;
    //    activeMessage = 0;
    //    isDialogueActive = true;
    //    Debug.Log("Started conversation! Messages Loaded: " + messages.Length);
    //    DisplayMessage();
    //}

    private void DisplayMessage()
    {
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;

        Actor actorToDisplay = currentActors[messageToDisplay.actorID];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;
    }

    public void NextMessage()
    {
        activeMessage++;
        if (activeMessage < currentMessages.Length)
        {
            DisplayMessage();
        }
        else
        {
            isDialogueActive = false;
            npcs.DisableDialogueBox();
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isDialogueActive)
        {
            NextMessage();
        }
    }
}
