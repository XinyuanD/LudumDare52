using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // components
    private Rigidbody2D rb;
    private BoxCollider2D collider2d;
    private Animator animator;

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
        animator = GetComponent<Animator>();
        transform.position = startPosition.value;
    }

    void FixedUpdate()
    {
        if (DialogueManager.isDialogueActive || VotingManager.isVoting)
        {
            animator.SetBool("IsWalking", false);
            return;
        }

        Vector2 velocity = moveInput * moveSpeed;
        if (velocity == new Vector2(Mathf.Epsilon, Mathf.Epsilon))
        {
            animator.SetBool("IsWalking", false);
        }
        else
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
            animator.SetBool("IsWalking", true);
        }
    }

    private void OnMove(InputValue value) 
    {
        moveInput = value.Get<Vector2>();
    }
}
