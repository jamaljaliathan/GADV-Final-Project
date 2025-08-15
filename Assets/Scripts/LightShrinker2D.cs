using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightShrinker2D : MonoBehaviour
{
    [Header("References")]
    public Light2D lanternLight;

    [Header("Light Shrink Settings")]
    public float shrinkAmountPerMove = 0.5f;
    public float minRadius = 1f;

    private Vector3 lastPosition;

    void Start()
    {
        if (lanternLight == null)
        {
            Debug.LogError("Lantern Light not assigned!");
            enabled = false;
            return;
        }

        lanternLight.pointLightOuterRadius = Mathf.Round(lanternLight.pointLightOuterRadius / shrinkAmountPerMove) * shrinkAmountPerMove;

        lastPosition = transform.position;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, lastPosition) > 0.01f)
        {
            float currentRadius = Mathf.Round(lanternLight.pointLightOuterRadius / shrinkAmountPerMove) * shrinkAmountPerMove;
            float newRadius = Mathf.Max(minRadius, currentRadius - shrinkAmountPerMove);
            lanternLight.pointLightOuterRadius = newRadius;

            lastPosition = transform.position;
        }
    }
}
