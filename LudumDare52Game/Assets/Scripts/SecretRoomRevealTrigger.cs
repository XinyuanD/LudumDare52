using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretRoomRevealTrigger : MonoBehaviour
{
    [SerializeField] private Vector3 camPosition;
    [SerializeField] private float camSize;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Camera.main.transform.position = camPosition;
            Camera.main.orthographicSize = camSize;
            this.gameObject.SetActive(false);
        }
    }
}
