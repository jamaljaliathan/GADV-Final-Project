using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Sprite closedSprite; // Sprite to show when the door is closed
    public Sprite openSprite; // Sprite to show when the door is open
    public GameObject levelClearText; // UI element shown when level is cleared
    public GameObject lockedText; // UI element shown when the door is locked
    private SpriteRenderer spriteRenderer; // Reference to this object's SpriteRenderer
    private bool isOpen = false; // Tracks if the door is already open

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component
        if (spriteRenderer != null && closedSprite != null)
            spriteRenderer.sprite = closedSprite; // Set door to closed sprite at start

        if (levelClearText != null)
            levelClearText.SetActive(false); // Hide level clear text at start

        if (lockedText != null)
            lockedText.SetActive(false); // Hide locked text at start
    }

    public void TryOpenDoor()
    {
        if (isOpen) return; // If door is already open, do nothing

        if (!SwitchController.isSwitchActivated) // If the switch is not activated
        {
            if (lockedText != null)
            {
                lockedText.SetActive(true); // Show "locked" message
                Invoke("HideLockedText", 2f); // Hide it after 2 seconds
            }
            return; // Stop here, door remains closed
        }

        isOpen = true; // Mark door as open

        if (spriteRenderer != null && openSprite != null)
            spriteRenderer.sprite = openSprite; // Change to open sprite

        if (levelClearText != null)
            levelClearText.SetActive(true); // Show level clear text

        Debug.Log("Door opened! Level Clear!"); // Log to console
    }

    private void HideLockedText()
    {
        if (lockedText != null)
            lockedText.SetActive(false); // Hide locked text UI
    }
}
