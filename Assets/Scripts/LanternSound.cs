using UnityEngine;

public class LanternSound : MonoBehaviour
{
    public AudioClip lanternLoop; // assign your looping lantern sound
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = lanternLoop;
        audioSource.loop = true; // keep looping
        audioSource.playOnAwake = true;
        audioSource.Play();
    }
}
