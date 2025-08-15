using UnityEngine;

public class SwitchInteraction : MonoBehaviour
{
    [Header("Interaction Settings")]
    public float activationDistance = 2f; // Distance at which player can interact
    public KeyCode interactKey = KeyCode.E;

    [Header("UI Prompt")]
    public GameObject interactPrompt;  // "Press E to interact" text
    public GameObject messageText;     // "Something has opened!" text

    [Header("Switch Sprites")]
    public Sprite closedSprite;
    public Sprite openSprite;

    private Transform player;
    private bool switchActivated = false;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer not found on the switch!");
        }

        if (interactPrompt != null) interactPrompt.SetActive(false);
        if (messageText != null) messageText.SetActive(false);

        // Set initial sprite to closed
        if (spriteRenderer != null && closedSprite != null)
            spriteRenderer.sprite = closedSprite;
    }

    void Update()
    {
        if (player == null) return;

        float dist = Vector2.Distance(player.position, transform.position);

        if (dist <= activationDistance)
        {
            // Show interact prompt if switch not yet activated
            if (interactPrompt != null && !switchActivated)
                interactPrompt.SetActive(true);

            // Press E to activate
            if (Input.GetKeyDown(interactKey) && !switchActivated)
            {
                ActivateSwitch();
            }
        }
        else
        {
            // Hide all UI when walking away
            if (interactPrompt != null) interactPrompt.SetActive(false);
            if (messageText != null) messageText.SetActive(false);
            switchActivated = false;

            // Reset sprite to closed when walking away
            if (spriteRenderer != null && closedSprite != null)
                spriteRenderer.sprite = closedSprite;
        }
    }

    void ActivateSwitch()
    {
        switchActivated = true;

        // Hide interact prompt
        if (interactPrompt != null) interactPrompt.SetActive(false);
        // Show message text
        if (messageText != null) messageText.SetActive(true);

        // Change sprite to open
        if (spriteRenderer != null && openSprite != null)
            spriteRenderer.sprite = openSprite;

        Debug.Log("Switch activated!");
        // TODO: Add additional logic here (e.g., open door)
    }
}
