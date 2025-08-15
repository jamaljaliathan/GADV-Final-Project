using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightShrinker2D : MonoBehaviour
{
    [Header("References")]
    public Light2D lanternLight; // Reference to the player's lantern light

    [Header("Light Shrink Settings")]
    public float shrinkAmountPerMove = 0.5f; // Amount the light radius shrinks per movement
    public float minRadius = 1f; // Minimum radius the light can shrink to

    private Vector3 lastPosition; // Tracks the last position of the player/object

    void Start()
    {
        if (lanternLight == null)
        {
            Debug.LogError("Lantern Light not assigned!"); // Log error if no light assigned
            enabled = false; // Disable this script
            return;
        }

        // Round the lantern's initial radius to nearest shrink step
        lanternLight.pointLightOuterRadius = Mathf.Round(lanternLight.pointLightOuterRadius / shrinkAmountPerMove) * shrinkAmountPerMove;

        lastPosition = transform.position; // Initialize last position
    }

    void Update()
    {
        // Check if the object has moved significantly since last frame
        if (Vector3.Distance(transform.position, lastPosition) > 0.01f)
        {
            // Round current radius to nearest shrink step
            float currentRadius = Mathf.Round(lanternLight.pointLightOuterRadius / shrinkAmountPerMove) * shrinkAmountPerMove;
            // Calculate new radius after shrinking, clamped to minimum
            float newRadius = Mathf.Max(minRadius, currentRadius - shrinkAmountPerMove);
            lanternLight.pointLightOuterRadius = newRadius; // Apply new radius

            lastPosition = transform.position; // Update last position
        }
    }
}
