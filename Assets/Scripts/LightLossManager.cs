using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Rendering.Universal;

public class LightLossManager : MonoBehaviour
{
    [Header("Light Settings")]
    public Light2D playerLight;
    public float minRadius = 1f;

    [Header("UI")]
    public TMP_Text loseText;

    [Header("Restart Settings")]
    public float restartDelay = 2f;

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

        LanternMovement player = GameObject.FindWithTag("Player")?.GetComponent<LanternMovement>();
        if (player != null)
            player.enabled = false;

        Invoke(nameof(RestartLevel), restartDelay);
    }

    void RestartLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
