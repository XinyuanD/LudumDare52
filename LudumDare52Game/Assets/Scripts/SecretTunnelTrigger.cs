using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecretTunnelTrigger : MonoBehaviour
{
    public Transform detectionPoint;
    public float detectionRadius;
    public LayerMask playerLayer;
    public GameObject interactionBox;

    [SerializeField] private Vector2 playerPosition;
    public VectorValue playerStorage;

    private void Start()
    {
        interactionBox.SetActive(false);
    }

    private void Update()
    {
        if (DetectPlayer())
        {
            interactionBox.SetActive(true);
            if (interactInput())
            {
                playerStorage.value = playerPosition;
                interactionBox.SetActive(false);
                SceneManager.LoadScene("RoomB");
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
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(detectionPoint.position, detectionRadius);
    }
}
