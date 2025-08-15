using UnityEngine;

public class LanternMovement : MonoBehaviour
{
    public float moveCooldown = 0.2f; // Minimum time between moves
    private float lastMoveTime; // Tracks the last time the player moved

    [HideInInspector]
    public bool canMove = false; // Whether the player is allowed to move

    void Update()
    {
        if (!canMove) return; // Exit if movement is disabled

        if (Time.time - lastMoveTime >= moveCooldown) // Check if cooldown has passed
        {
            Vector3 move = Vector3.zero; // Movement direction for this frame

            if (Input.GetKeyDown(KeyCode.W))
                move = Vector3.up; // Move up
            else if (Input.GetKeyDown(KeyCode.S))
                move = Vector3.down; // Move down
            else if (Input.GetKeyDown(KeyCode.A))
                move = Vector3.left; // Move left
            else if (Input.GetKeyDown(KeyCode.D))
                move = Vector3.right; // Move right

            if (move != Vector3.zero) // If any movement key was pressed
            {
                transform.position += move; // Apply movement
                lastMoveTime = Time.time; // Reset last move time
            }
        }
    }
}
