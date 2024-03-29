using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomTrigger : MonoBehaviour
{
    [SerializeField] private int targetSceneIndex;
    [SerializeField] private Vector2 playerPosition;
    public VectorValue playerStorage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerStorage.value = playerPosition;
            if (targetSceneIndex == 4)
            {
                PlayerController.hasEnteredRoomB = true;
            }

            SceneManager.LoadScene(targetSceneIndex);
        }
    }
}
