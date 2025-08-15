using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightFadeManager : MonoBehaviour
{
    public Light2D globalLight;       // Assign your Global Light 2D
    public float fadeDuration = 3f;   // How long to fade (seconds)

    private float startIntensity;
    private float targetIntensity = 0f; // Final intensity after fade
    private float fadeTimer;

    void Start()
    {
        if (globalLight == null)
        {
            Debug.LogError("Global Light not assigned!");
            enabled = false;
            return;
        }

        startIntensity = globalLight.intensity;
        fadeTimer = 0f;
    }

    void Update()
    {
        if (fadeTimer < fadeDuration)
        {
            fadeTimer += Time.deltaTime;
            float t = Mathf.Clamp01(fadeTimer / fadeDuration);

            // Smooth fade
            globalLight.intensity = Mathf.Lerp(startIntensity, targetIntensity, t);
        }
    }
}
