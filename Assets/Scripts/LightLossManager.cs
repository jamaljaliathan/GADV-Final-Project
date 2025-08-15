using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Rendering.Universal;

public class LightLossManager : MonoBehaviour
{
    [Header("Light Settings")]
    public Light2D playerLight; // Reference to the player's lantern light
    public float minRadius = 1f; // Minimum radius before the player loses

    [Header("UI")]
    public TMP_Text loseText; // UI text to display when player loses

    [Header("Restart Settings")]
    public float restartDelay = 2f; // Delay before restarting the level

    private bool hasLost = false; // Tracks if the player has already lost

    void Start()
    {
        if (loseText != null)
            loseText.gameObject.SetActive(false); // Hide lose text at start
    }

    void Update()
    {
        if (hasLost) return; // Exit if player already lost

        if (playerLight != null && playerLight.pointLightOuterRadius <= minRadius)
        {
            LoseGame(); // Trigger loss if light is too small
        }
    }

    void LoseGame()
    {
        hasLost = true; // Mark that the player has lost

        if (loseText != null)
            loseText.gameObject.SetActive(true); // Show lose text

        Debug.Log("You Lose!"); // Log for debugging

        LanternMovement player = GameObject.FindWithTag("Player")?.GetComponent<LanternMovement>();
        if (player != null)
            player.enabled = false; // Disable player movement

        Invoke(nameof(RestartLevel), restartDelay); // Restart level after delay
    }

    void RestartLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene(); // Get current scene
        SceneManager.LoadScene(currentScene.name); // Reload the scene
    }
}
