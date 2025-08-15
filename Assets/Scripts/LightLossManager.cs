using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Rendering.Universal;

public class LightLossManager : MonoBehaviour
{
    [Header("Light Settings")]
    public Light2D playerLight;   // Assign your player's Light2D
    public float minRadius = 1f;  // When this is reached, player loses

    [Header("UI")]
    public TMP_Text loseText;     // Assign the "You Lose" TMP text

    [Header("Restart Settings")]
    public float restartDelay = 2f; // Time in seconds before restarting

    private bool hasLost = false;

    void Start()
    {
        if (loseText != null)
            loseText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (hasLost) return;

        if (playerLight != null && playerLight.pointLightOuterRadius <= minRadius)
        {
            LoseGame();
        }
    }

    void LoseGame()
    {
        hasLost = true;

        if (loseText != null)
            loseText.gameObject.SetActive(true);

        Debug.Log("You Lose!");

        // Optional: disable player movement
        LanternMovement player = GameObject.FindWithTag("Player")?.GetComponent<LanternMovement>();
        if (player != null)
            player.enabled = false;

        // Restart the level after a delay
        Invoke(nameof(RestartLevel), restartDelay);
    }

    void RestartLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
