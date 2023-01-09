using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VotingTrigger : MonoBehaviour
{
    public GameObject votingScreen;

    public Transform detectionPoint;
    public float detectionRadius;
    public LayerMask playerLayer;
    public GameObject interactionBox;

    private void Start()
    {
        DisableVotingScreen();
    }

    private void Update()
    {
        if (DetectPlayer())
        {
            if (!VotingManager.isVoting && !VotingManager.hasMadeChoice)
            {
                interactionBox.SetActive(true);
            }
            if (interactInput())
            {
                interactionBox.SetActive(false);
                votingScreen.SetActive(true);
                VotingManager.isVoting = true;
            }
        }
        else
        {
            interactionBox.SetActive(false);
        }
    }

    private bool interactInput()
    {
        return Input.GetKeyDown(KeyCode.E);
    }

    private bool DetectPlayer()
    {
        return Physics2D.OverlapCircle(detectionPoint.position, detectionRadius, playerLayer);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(detectionPoint.position, detectionRadius);
    }
    
    public void DisableVotingScreen()
    {
        VotingManager.isVoting = false;
        votingScreen.SetActive(false);
    }
}

