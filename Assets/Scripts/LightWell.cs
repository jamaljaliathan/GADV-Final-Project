using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightWell : MonoBehaviour
{
    [Header("Restore Settings")]
    public float restoreStep = 0.5f;
    public float maxRadius = 5f;
    public float restoreInterval = 0.5f;
    public float activationDistance = 2f;

    private float restoreTimer;

    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) return;

        Light2D lanternLight = player.GetComponentInChildren<Light2D>();
        if (lanternLight == null) return;

        float dist = Vector2.Distance(player.transform.position, transform.position);

        if (dist <= activationDistance)
        {
            restoreTimer += Time.deltaTime;

            if (restoreTimer >= restoreInterval)
            {
                float newRadius = lanternLight.pointLightOuterRadius + restoreStep;
                newRadius = Mathf.Round(newRadius * 2f) / 2f;
                lanternLight.pointLightOuterRadius = Mathf.Min(maxRadius, newRadius);
                restoreTimer = 0f;
            }
        }
        else
        {
            restoreTimer = 0f;
        }
    }
}
