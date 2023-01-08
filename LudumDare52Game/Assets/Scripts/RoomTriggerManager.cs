using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTriggerManager : MonoBehaviour
{
    public GameObject triggerA;
    public GameObject triggerB;
    public GameObject triggerC;
    public Item itemTracker;

    void Start()
    {
        // player hasn't picked up key
        if (!itemTracker.hasItems[0])
        {
            triggerA.SetActive(false);
            triggerB.SetActive(false);
            triggerC.SetActive(false);
        }
        // player hasn't picked up letter
        else if (!itemTracker.hasItems[1])
        {
            triggerB.SetActive(false);
            triggerC.SetActive(false);
        }
        // player hasn't entered B yet
        else if (!PlayerController.hasEnteredRoomB)
        {
            triggerC.SetActive(false);
        }
    }

}
