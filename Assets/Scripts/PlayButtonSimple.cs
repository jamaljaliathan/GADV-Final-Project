using UnityEngine;
using UnityEngine.UI;

public class PlayButtonSimple : MonoBehaviour
{
    public Button playButton;
    public GameObject startMenuUI;
    public LanternMovement playerMovement;  // Assign your player here

    private void Start()
    {
        if (playButton != null)
        {
            playButton.onClick.AddListener(OnPlayClicked);
        }
    }

    private void OnPlayClicked()
    {
        if (startMenuUI != null)
            startMenuUI.SetActive(false);  // Hide start menu

        if (playerMovement != null)
            playerMovement.canMove = true; // Enable player movement
    }
}
