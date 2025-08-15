using UnityEngine;
using TMPro;
using UnityEngine.Rendering.Universal;

public class LightIndicatorText : MonoBehaviour
{
    [Header("References")]
    public Light2D playerLight; // Reference to the player's lantern light
    public TMP_Text lightText; // Reference to the UI text component

    [Header("Settings")]
    public float maxRadius = 10f; // Maximum light radius for percentage calculation
    public float minRadius = 1f; // Minimum light radius for percentage calculation

    void Update()
    {
        if (playerLight == null || lightText == null) return;
        // Exit if references are not assigned

        // Calculate current light level as a percentage between min and max
        float percent = Mathf.Clamp01((playerLight.pointLightOuterRadius - minRadius) / (maxRadius - minRadius)) * 100f;

        // Update the text UI with the rounded percentage
        lightText.text = $"Light: {Mathf.RoundToInt(percent)}%";
    }
}
