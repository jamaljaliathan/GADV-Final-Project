using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Sprite closedSprite;
    public Sprite openSprite;
    public GameObject levelClearText;   // Assign your "Level Clear" UI text
    public GameObject lockedText;       // Assign your "Locked" UI text

    private SpriteRenderer spriteRenderer;
    private bool isOpen = false;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null && closedSprite != null)
            spriteRenderer.sprite = closedSprite;

        if (levelClearText != null)
            levelClearText.SetActive(false);

        if (lockedText != null)
            lockedText.SetActive(false);
    }

    public void TryOpenDoor()
    {
        if (isOpen) return;

        // Door cannot open if switch hasn’t activated
        if (!SwitchController.isSwitchActivated)
        {
            if (lockedText != null)
            {
                lockedText.SetActive(true);
                Invoke("HideLockedText", 2f); // Hide after 2 seconds
            }
            return;
        }

        // Open the door
        isOpen = true;

        if (spriteRenderer != null && openSprite != null)
            spriteRenderer.sprite = openSprite;

        if (levelClearText != null)
            levelClearText.SetActive(true);

        Debug.Log("Door opened! Level Clear!");
    }

    private void HideLockedText()
    {
        if (lockedText != null)
            lockedText.SetActive(false);
    }
}
