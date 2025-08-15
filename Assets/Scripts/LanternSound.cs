using UnityEngine;

public class LanternSound : MonoBehaviour
{
    public AudioClip lanternLoop;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = lanternLoop;
        audioSource.loop = true;
        audioSource.playOnAwake = true;
        audioSource.Play();
    }
}
