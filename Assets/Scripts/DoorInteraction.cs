using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    public DoorController door; // Reference to the DoorController to interact with

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Check if the collider belongs to the player
        {
            door.TryOpenDoor(); // Attempt to open the door
        }
    }
}
