using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Mirror2D : MonoBehaviour
{
    [Header("References")]
    public Light2D playerLight;
    public Light2D reflectedLight;

    [Header("Settings")]
    public float activationDistance = 3f;

    void Update()
    {
        if (playerLight == null || reflectedLight == null)
            return;

        float distance = Vector2.Distance(transform.position, playerLight.transform.position);

        if (distance <= activationDistance)
        {
            reflectedLight.enabled = true;

            reflectedLight.pointLightOuterRadius = playerLight.pointLightOuterRadius;

            Vector2 mirrorNormal = transform.up;
            Vector2 incomingDir = playerLight.transform.right;

            Vector2 reflectedDir = Vector2.Reflect(incomingDir, mirrorNormal);

            float angle = Mathf.Atan2(reflectedDir.y, reflectedDir.x) * Mathf.Rad2Deg;
            reflectedLight.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        else
        {
            reflectedLight.enabled = false;
        }
    }
}
