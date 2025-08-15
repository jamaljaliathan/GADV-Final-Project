using UnityEngine;

public class LanternSound : MonoBehaviour
{
    public AudioClip lanternLoop; // The looping audio clip for the lantern
    private AudioSource audioSource; // AudioSource component to play the sound

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        // Add an AudioSource component to this GameObject
        audioSource.clip = lanternLoop; // Assign the lantern loop clip
        audioSource.loop = true; // Make the sound loop continuously
        audioSource.playOnAwake = true; // Play automatically when the scene starts
        audioSource.Play(); // Start playing the audio
    }
}
