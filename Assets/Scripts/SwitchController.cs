using UnityEngine;

public class SwitchController : MonoBehaviour
{
    public static bool isSwitchActivated = false;
    public DoorController door;
    public KeyCode interactKey = KeyCode.E;
    public GameObject interactPrompt;

    private bool playerInRange = false;

    void Start()
    {
        if (interactPrompt != null)
            interactPrompt.SetActive(false);
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(interactKey))
        {
            ActivateSwitch();
        }
    }

    private void ActivateSwitch()
    {
        isSwitchActivated = true;

        if (interactPrompt != null)
            interactPrompt.SetActive(false);

        Debug.Log("Switch activated!");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            if (interactPrompt != null)
                interactPrompt.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            if (interactPrompt != null)
                interactPrompt.SetActive(false);
        }
    }
}
