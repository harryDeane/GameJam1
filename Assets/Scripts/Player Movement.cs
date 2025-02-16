using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the player movement
    public float jumpForce = 5f; // Force applied when jumping
    public int maxJumps = 1; // Number of jumps allowed after initial jump
    public Rigidbody rb; // Reference to the Rigidbody component
    public Transform groundCheck; // Empty GameObject to check if the player is grounded
    public float groundDistance = 0.4f; // Distance to check for ground
    public LayerMask groundMask; // LayerMask to define what is considered ground

    private Vector3 movement; // Stores the player's movement input
    private bool isGrounded; // Tracks whether the player is on the ground
    private int jumpsRemaining; // Tracks how many jumps the player has left

    void Start()
    {
        jumpsRemaining = maxJumps; // Initialize jumps
    }

    void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // Reset jumps when grounded
        if (isGrounded)
        {
            jumpsRemaining = maxJumps;
        }

        // Input handling for movement
        movement.x = Input.GetAxisRaw("Horizontal"); // Left/Right movement
        movement.z = Input.GetAxisRaw("Vertical"); // Forward/Backward movement

        // Normalize movement vector to prevent faster diagonal movement
        movement = movement.normalized;

        // Jumping
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                Jump(); // Jump when grounded
            }
            else if (jumpsRemaining > 0)
            {
                Jump(); // Double jump in mid-air
            }
        }
    }

    void FixedUpdate()
    {
        // Movement calculation and application
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z); // Reset vertical velocity before jumping
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // Apply upward force
        jumpsRemaining--; // Decrease jumps remaining
    }
}