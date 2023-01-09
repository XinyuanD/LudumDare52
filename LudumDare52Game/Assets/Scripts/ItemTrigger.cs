using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTrigger : MonoBehaviour
{
    public Transform detectionPoint;
    public float detectionRadius;
    public LayerMask playerLayer;

    public int itemID; // 0 is Key, 1 is Letter, 2 is Drugs, 3 is Dagger
    public GameObject interactionBox;
    public Item itemTracker;

    private void Start()
    {
        if (itemTracker.hasItems[itemID])
        {
            this.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (DetectPlayer())
        {
            interactionBox.SetActive(true);
            if (interactInput())
            {
                PlayerController.hasItems[itemID] = true;
                itemTracker.hasItems[itemID] = true;
                interactionBox.SetActive(false);
                this.gameObject.SetActive(false);
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
}
