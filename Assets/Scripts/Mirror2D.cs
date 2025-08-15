using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Mirror2D : MonoBehaviour
{
    [Header("References")]
    public Light2D playerLight; // Reference to the player's light
    public Light2D reflectedLight; // Reference to the mirror's reflected light

    [Header("Settings")]
    public float activationDistance = 3f; // Distance at which the mirror activates

    void Update()
    {
        if (playerLight == null || reflectedLight == null)
            return; // Exit if lights are not assigned

        float distance = Vector2.Distance(transform.position, playerLight.transform.position);
        // Calculate distance between mirror and player light

        if (distance <= activationDistance)
        {
            reflectedLight.enabled = true; // Enable reflected light

            reflectedLight.pointLightOuterRadius = playerLight.pointLightOuterRadius;
            // Match reflected light radius to player light

            Vector2 mirrorNormal = transform.up; // Mirror's facing direction (normal)
            Vector2 incomingDir = playerLight.transform.right; // Direction of incoming light

            Vector2 reflectedDir = Vector2.Reflect(incomingDir, mirrorNormal);
            // Calculate reflected direction based on mirror normal

            float angle = Mathf.Atan2(reflectedDir.y, reflectedDir.x) * Mathf.Rad2Deg;
            // Convert reflected direction to angle in degrees
            reflectedLight.transform.rotation = Quaternion.Euler(0, 0, angle);
            // Rotate reflected light to match reflected direction
        }
        else
        {
            reflectedLight.enabled = false; // Disable reflected light if player is too far
        }
    }
}
