using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Vector2 startPosition;
    public VectorValue playerPosition;
    public Item itemTracker;

    public void StartGame()
    {
        playerPosition.value = startPosition;
        for (int i = 0; i < itemTracker.hasItems.Length; i++)
        {
            itemTracker.hasItems[i] = false;
        }
        SceneManager.LoadScene("MurderRoom");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
