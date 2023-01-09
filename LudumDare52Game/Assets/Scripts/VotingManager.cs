using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VotingManager : MonoBehaviour
{
    public VotingTrigger trigger;
    public GameObject winScreen;
    public GameObject loseScreen;
    public static bool isVoting = false;
    [SerializeField] private int playerChoice;
    public static bool hasMadeChoice = false;

    private void Update()
    {
        if (playerChoice == 2)
        {
            hasMadeChoice = true;
            winScreen.SetActive(true);
            trigger.DisableVotingScreen();
        }
        else if (playerChoice == 1 || playerChoice == 3)
        {
            hasMadeChoice = true;
            loseScreen.SetActive(true);
            trigger.DisableVotingScreen();
        }
    }

    public void VoteA()
    {
        playerChoice = 1;
    }

    public void VoteB()
    {
        playerChoice = 2;
    }

    public void VoteC()
    {
        playerChoice = 3;
    }
}
