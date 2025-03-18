using UnityEngine;
using System.Collections.Generic;

public class GhostController : MonoBehaviour
{
    public float syncDelay = 0.5f; // Increased delay to clearly see lag
    public float interpolationSpeed = 6f; // Controls smooth movement transitions

    private Rigidbody rb;
    private Queue<(float timestamp, PlayerState)> jumpQueue = new Queue<(float, PlayerState)>(); // Stores player jumps with timestamps

    private Vector3 positionOffset; // Keeps the ghost beside the player
    private Transform playerTransform; // Reference to the player

    private void OnEnable()
    {
        PlayerController.OnJump += StoreJump;
    }

    private void OnDisable()
    {
        PlayerController.OnJump -= StoreJump;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Find the player and store the side-by-side offset
        playerTransform = FindObjectOfType<PlayerController>().transform;
        positionOffset = transform.position - playerTransform.position;
    }

    private void FixedUpdate()
    {
        // Keep the ghost at a fixed side position relative to the player
        if (playerTransform != null)
        {
            Vector3 targetPosition = playerTransform.position + positionOffset;
            transform.position = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);
        }

        // Process jump only after the delay has passed
        if (jumpQueue.Count > 0)
        {
            var (timestamp, state) = jumpQueue.Peek(); // Look at the first stored jump

            if (Time.time >= timestamp) // Only jump when the delay has passed
            {
                jumpQueue.Dequeue();
                PerformJump(state);
            }
        }
    }

    private void StoreJump(PlayerState state)
    {
        // Store the player's jump state with a delay timestamp
        float executionTime = Time.time + syncDelay;
        jumpQueue.Enqueue((executionTime, state));
    }

    private void PerformJump(PlayerState state)
    {
        // Apply delayed jump while keeping ghost at the fixed side position
        rb.velocity = new Vector3(rb.velocity.x, state.verticalVelocity, rb.velocity.z);
    }
}
