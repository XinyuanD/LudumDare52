using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTrigger : MonoBehaviour
{
    public int itemID; // 0 is Key, 1 is Letter, 2 is Drugs, 3 is Dagger
    public Item itemTracker;

    private void Start()
    {
        if (itemTracker.hasItems[itemID])
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (itemID == 0)
            {
                PlayerController.hasKey = true;
            }
            else if (itemID == 1)
            {
                PlayerController.hasLetter = true;
            }
            else if (itemID == 2)
            {
                PlayerController.hasDrugs = true;
            }
            else if (itemID == 3)
            {
                PlayerController.hasDagger = true;
            }
            
            itemTracker.hasItems[itemID] = true;
            this.gameObject.SetActive(false);
        }
    }
}
