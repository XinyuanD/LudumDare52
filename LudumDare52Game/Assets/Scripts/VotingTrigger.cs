using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VotingTrigger : MonoBehaviour
{
    public GameObject votingScreen;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            votingScreen.SetActive(true);
            VotingManager.isVoting = true;
        }
    }

    void Start()
    {
        DisableVotingScreen();
    }

    public void DisableVotingScreen()
    {
        VotingManager.isVoting = false;
        votingScreen.SetActive(false);
    }
    
}
