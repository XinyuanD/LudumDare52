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
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider2d = GetComponent<BoxCollider2D>();
        transform.position = startPosition.value;
    }

    void FixedUpdate()
    {
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
