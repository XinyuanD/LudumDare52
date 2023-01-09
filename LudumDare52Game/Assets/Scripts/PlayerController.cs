using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // components
    private Rigidbody2D rb;
    private BoxCollider2D collider2d;

    // variables
    [SerializeField] private float moveSpeed = 5f;
    private Vector2 moveInput;
    public VectorValue startPosition;

    // item checks
    public static bool[] hasItems = new bool[4]; // 0 is Key, 1 is Letter, 2 is Drugs, 3 is Dagger
    public static bool hasEnteredRoomB = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider2d = GetComponent<BoxCollider2D>();
        transform.position = startPosition.value;
    }

    void FixedUpdate()
    {
        if (DialogueManager.isDialogueActive || VotingManager.isVoting)
        {
            return;
        }

        Move();
    }

    private void Move()
    {
        Vector2 velocity = moveInput * moveSpeed;
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
    }
    
    private void OnMove(InputValue value) 
    {
        moveInput = value.Get<Vector2>();
    }
}
