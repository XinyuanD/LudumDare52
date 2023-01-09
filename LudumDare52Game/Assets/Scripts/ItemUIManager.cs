using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUIManager : MonoBehaviour
{
    public GameObject[] itemImages = new GameObject[4]; // 0 is Key, 1 is Letter, 2 is Drugs, 3 is Dagger
    public Item itemTracker;

    void Start()
    {
        foreach (GameObject i in itemImages)
        {
            i.SetActive(false);
        }
    }
    
    void Update()
    {
        if (VotingManager.isVoting || VotingManager.hasMadeChoice)
        {
            SetItemImageState(false);
        }
        else
        {
            SetItemImageState(true);
        }
        
    }

    private void SetItemImageState(bool state)
    {
        for (int i = 0; i < itemImages.Length; i++)
        {
            if (itemTracker.hasItems[i])
            {
                itemImages[i].SetActive(state);
            }
        }
    }
}
