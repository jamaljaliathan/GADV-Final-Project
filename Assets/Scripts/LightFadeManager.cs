using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightFadeManager : MonoBehaviour
{
    public Light2D globalLight; // Reference to the global 2D light
    public float fadeDuration = 3f; // Duration over which the light fades
    private float startIntensity; // Initial intensity of the light
    private float targetIntensity = 0f; // Target intensity (fade to this value)
    private float fadeTimer; // Tracks elapsed time during fade

    void Start()
    {
        if (globalLight == null)
        {
            Debug.LogError("Global Light not assigned!"); // Error if no light assigned
            enabled = false; // Disable this script
            return;
        }

        startIntensity = globalLight.intensity; // Store the initial intensity
        fadeTimer = 0f; // Initialize timer
    }

    void Update()
    {
        if (fadeTimer < fadeDuration) // Only fade while time is remaining
        {
            fadeTimer += Time.deltaTime; // Increment fade timer
            float t = Mathf.Clamp01(fadeTimer / fadeDuration);
            // Normalized time (0 to 1)

            globalLight.intensity = Mathf.Lerp(startIntensity, targetIntensity, t);
            // Smoothly interpolate light intensity from start to target
        }
    }
}
