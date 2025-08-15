using UnityEngine;

public class LanternMovement : MonoBehaviour
{
    public float moveCooldown = 0.2f;  // Time delay between moves
    private float lastMoveTime;

    [HideInInspector]
    public bool canMove = false;  // Player cannot move until Play is clicked

    void Update()
    {
        if (!canMove) return;  // Stop movement if not allowed

        if (Time.time - lastMoveTime >= moveCooldown)
        {
            Vector3 move = Vector3.zero;

            if (Input.GetKeyDown(KeyCode.W))
                move = Vector3.up;
            else if (Input.GetKeyDown(KeyCode.S))
                move = Vector3.down;
            else if (Input.GetKeyDown(KeyCode.A))
                move = Vector3.left;
            else if (Input.GetKeyDown(KeyCode.D))
                move = Vector3.right;

            if (move != Vector3.zero)
            {
                transform.position += move;
                lastMoveTime = Time.time;
            }
        }
    }
}
