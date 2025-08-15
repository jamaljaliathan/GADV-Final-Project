using UnityEngine;

public class SwitchController : MonoBehaviour
{
    public static bool isSwitchActivated = false; // Tracks if any switch has been activated globally
    public DoorController door; // Reference to the door controlled by this switch
    public KeyCode interactKey = KeyCode.E; // Key to activate the switch
    public GameObject interactPrompt; // UI prompt shown when player is in range

    private bool playerInRange = false; // Tracks if the player is near the switch

    void Start()
    {
        if (interactPrompt != null)
            interactPrompt.SetActive(false); // Hide prompt at start
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(interactKey))
        {
            ActivateSwitch(); // Activate switch if player presses key while in range
        }
    }

    private void ActivateSwitch()
    {
        isSwitchActivated = true; // Mark switch as activated

        if (interactPrompt != null)
            interactPrompt.SetActive(false); // Hide the prompt

        Debug.Log("Switch activated!"); // Log for debugging
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true; // Player is now in range
            if (interactPrompt != null)
                interactPrompt.SetActive(true); // Show prompt
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false; // Player left range
            if (interactPrompt != null)
                interactPrompt.SetActive(false); // Hide prompt
        }
    }
}
