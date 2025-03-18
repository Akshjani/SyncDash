using UnityEngine;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 7f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody rb;
    private bool isGrounded;
    private bool jumpRequest = false;

    // Queue for syncing movement (simulating network lag)
    private Queue<PlayerState> jumpSyncQueue = new Queue<PlayerState>();

    public delegate void OnPlayerJump(PlayerState state);
    public static event OnPlayerJump OnJump;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        CheckGround();

        // Register a jump request when the player presses Space
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jumpRequest = true;
        }
    }

    private void FixedUpdate()
    {
        if (jumpRequest)
        {
            Jump();
            jumpRequest = false; // Reset request after execution
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);

        // Add jump data to queue for syncing with the ghost
        jumpSyncQueue.Enqueue(new PlayerState(transform.position, rb.velocity.y));
        //if (jumpSyncQueue.Count > 1) // Simulating lag of 5 frames
        //{
        //    OnJump?.Invoke(jumpSyncQueue.Dequeue());
        //}
        OnJump?.Invoke(jumpSyncQueue.Dequeue());

        Debug.Log("Jump Executed!");
    }

    private void CheckGround()
    {
        Vector3 boxSize = new Vector3(0.5f, 0.05f, 0.5f);
        isGrounded = Physics.CheckBox(groundCheck.position, boxSize / 2, Quaternion.identity, groundLayer);


    }

}

// Struct for syncing movement
public struct PlayerState
{
    public Vector3 position;
    public float verticalVelocity;

    public PlayerState(Vector3 pos, float vVel)
    {
        position = pos;
        verticalVelocity = vVel;
    }
}
