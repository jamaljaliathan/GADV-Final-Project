using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightWell : MonoBehaviour
{
    [Header("Restore Settings")]
    public float restoreStep = 0.5f; // Amount to increase lantern radius each step
    public float maxRadius = 5f; // Maximum radius lantern can reach
    public float restoreInterval = 0.5f; // Time between each restoration step
    public float activationDistance = 2f; // Distance at which the light well activates

    private float restoreTimer; // Timer to track restoration intervals

    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        // Find the player object by tag
        if (player == null) return; // Exit if no player found

        Light2D lanternLight = player.GetComponentInChildren<Light2D>();
        // Get the lantern light component from player
        if (lanternLight == null) return; // Exit if no light found

        float dist = Vector2.Distance(player.transform.position, transform.position);
        // Calculate distance between player and light well

        if (dist <= activationDistance)
        {
            restoreTimer += Time.deltaTime; // Increment timer

            if (restoreTimer >= restoreInterval)
            {
                float newRadius = lanternLight.pointLightOuterRadius + restoreStep;
                // Increase lantern radius
                newRadius = Mathf.Round(newRadius * 2f) / 2f;
                // Round to nearest 0.5 for smoother increments
                lanternLight.pointLightOuterRadius = Mathf.Min(maxRadius, newRadius);
                // Clamp to maximum radius
                restoreTimer = 0f; // Reset timer
            }
        }
        else
        {
            restoreTimer = 0f; // Reset timer if player is too far
        }
    }
}
