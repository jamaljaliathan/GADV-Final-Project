using UnityEngine;
using TMPro;
using UnityEngine.Rendering.Universal;

public class LightIndicatorText : MonoBehaviour
{
    [Header("References")]
    public Light2D playerLight;
    public TMP_Text lightText;

    [Header("Settings")]
    public float maxRadius = 10f;
    public float minRadius = 1f;

    void Update()
    {
        if (playerLight == null || lightText == null) return;

        float percent = Mathf.Clamp01((playerLight.pointLightOuterRadius - minRadius) / (maxRadius - minRadius)) * 100f;

        lightText.text = $"Light: {Mathf.RoundToInt(percent)}%";
    }
}
