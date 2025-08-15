using UnityEngine;

public class SwitchInteraction : MonoBehaviour
{
    [Header("Interaction Settings")]
    public float activationDistance = 2f;
    public KeyCode interactKey = KeyCode.E;

    [Header("UI Prompt")]
    public GameObject interactPrompt;
    public GameObject messageText;

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

        if (spriteRenderer != null && closedSprite != null)
            spriteRenderer.sprite = closedSprite;
    }

    void Update()
    {
        if (player == null) return;

        float dist = Vector2.Distance(player.position, transform.position);

        if (dist <= activationDistance)
        {
            if (interactPrompt != null && !switchActivated)
                interactPrompt.SetActive(true);

            if (Input.GetKeyDown(interactKey) && !switchActivated)
            {
                ActivateSwitch();
            }
        }
        else
        {
            if (interactPrompt != null) interactPrompt.SetActive(false);
            if (messageText != null) messageText.SetActive(false);
            switchActivated = false;

            if (spriteRenderer != null && closedSprite != null)
                spriteRenderer.sprite = closedSprite;
        }
    }

    void ActivateSwitch()
    {
        switchActivated = true;

        if (interactPrompt != null) interactPrompt.SetActive(false);
        if (messageText != null) messageText.SetActive(true);

        if (spriteRenderer != null && openSprite != null)
            spriteRenderer.sprite = openSprite;

        Debug.Log("Switch activated!");
    }
}
