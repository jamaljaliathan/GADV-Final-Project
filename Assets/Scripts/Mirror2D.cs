using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Mirror2D : MonoBehaviour
{
    [Header("References")]
    public Light2D playerLight;       // Player lantern
    public Light2D reflectedLight;    // Child light attached to mirror

    [Header("Settings")]
    public float activationDistance = 3f;  // Distance to player for mirror to activate

    void Update()
    {
        if (playerLight == null || reflectedLight == null)
            return;

        // Calculate distance to player
        float distance = Vector2.Distance(transform.position, playerLight.transform.position);

        if (distance <= activationDistance)
        {
            // Enable reflected light when player is close
            reflectedLight.enabled = true;

            // Match radius to player light radius
            reflectedLight.pointLightOuterRadius = playerLight.pointLightOuterRadius;

            // Calculate mirror normal
            Vector2 mirrorNormal = transform.up;  // Mirror "faces" along its Y axis
            Vector2 incomingDir = playerLight.transform.right; // Player light direction

            // Reflect the direction
            Vector2 reflectedDir = Vector2.Reflect(incomingDir, mirrorNormal);

            // Rotate the reflected light to match reflection
            float angle = Mathf.Atan2(reflectedDir.y, reflectedDir.x) * Mathf.Rad2Deg;
            reflectedLight.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        else
        {
            // Turn off light if player is far
            reflectedLight.enabled = false;
        }
    }
}
