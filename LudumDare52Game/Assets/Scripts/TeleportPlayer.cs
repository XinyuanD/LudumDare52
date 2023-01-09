using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public PlayerController player;
    [SerializeField] private Vector2 position;
    [SerializeField] private bool isExit;
    public GameObject entrance;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player.transform.position = position;
            if (isExit)
            {
                entrance.SetActive(true);
            }
        }
    }
}
