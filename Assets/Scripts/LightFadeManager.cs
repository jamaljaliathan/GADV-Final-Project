using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightFadeManager : MonoBehaviour
{
    public Light2D globalLight;
    public float fadeDuration = 3f;
    private float startIntensity;
    private float targetIntensity = 0f;
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

            globalLight.intensity = Mathf.Lerp(startIntensity, targetIntensity, t);
        }
    }
}
