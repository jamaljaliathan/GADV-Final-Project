using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    public DoorController door;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            door.TryOpenDoor();
        }
    }
}
