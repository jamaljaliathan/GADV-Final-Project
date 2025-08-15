using UnityEngine;

public class SwitchInteraction : MonoBehaviour
{
    [Header("Interaction Settings")]
    public float activationDistance = 2f; // Distance at which player can interact with the switch
    public KeyCode interactKey = KeyCode.E; // Key used to activate the switch

    [Header("UI Prompt")]
    public GameObject interactPrompt; // UI prompt shown when player is in range
    public GameObject messageText; // UI message shown when switch is activated

    [Header("Switch Sprites")]
    public Sprite closedSprite; // Sprite when switch is inactive
    public Sprite openSprite; // Sprite when switch is activated

    private Transform player; // Reference to the player transform
    private bool switchActivated = false; // Tracks if the switch has been activated
    private SpriteRenderer spriteRenderer; // Reference to this switch's SpriteRenderer

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform; // Find player
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get SpriteRenderer component

        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer not found on the switch!"); // Log error if missing
        }

        if (interactPrompt != null) interactPrompt.SetActive(false); // Hide interact prompt
        if (messageText != null) messageText.SetActive(false); // Hide message text

        if (spriteRenderer != null && closedSprite != null)
            spriteRenderer.sprite = closedSprite; // Set initial sprite to closed
    }

    void Update()
    {
        if (player == null) return; // Exit if player not found

        float dist = Vector2.Distance(player.position, transform.position); // Distance to player

        if (dist <= activationDistance)
        {
            if (interactPrompt != null && !switchActivated)
                interactPrompt.SetActive(true); // Show prompt if in range and not activated

            if (Input.GetKeyDown(interactKey) && !switchActivated)
            {
                ActivateSwitch(); // Activate switch on key press
            }
        }
        else
        {
            if (interactPrompt != null) interactPrompt.SetActive(false); // Hide prompt if out of range
            if (messageText != null) messageText.SetActive(false); // Hide message text
            switchActivated = false; // Reset switch

            if (spriteRenderer != null && closedSprite != null)
                spriteRenderer.sprite = closedSprite; // Reset sprite
        }
    }

    void ActivateSwitch()
    {
        switchActivated = true; // Mark switch as activated

        if (interactPrompt != null) interactPrompt.SetActive(false); // Hide prompt
        if (messageText != null) messageText.SetActive(true); // Show activation message

        if (spriteRenderer != null && openSprite != null)
            spriteRenderer.sprite = openSprite; // Change sprite to open

        Debug.Log("Switch activated!"); // Log activation
    }
}
