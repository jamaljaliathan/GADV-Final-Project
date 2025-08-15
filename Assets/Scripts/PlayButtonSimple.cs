using UnityEngine;
using UnityEngine.UI;

public class PlayButtonSimple : MonoBehaviour
{
    public Button playButton; // Reference to the UI Play button
    public GameObject startMenuUI; // Reference to the start menu UI panel
    public LanternMovement playerMovement; // Reference to the player's movement script

    private void Start()
    {
        if (playButton != null)
        {
            playButton.onClick.AddListener(OnPlayClicked);
            // Add a listener to call OnPlayClicked when button is pressed
        }
    }

    private void OnPlayClicked()
    {
        if (startMenuUI != null)
            startMenuUI.SetActive(false); // Hide the start menu

        if (playerMovement != null)
            playerMovement.canMove = true; // Enable player movement
    }
}
