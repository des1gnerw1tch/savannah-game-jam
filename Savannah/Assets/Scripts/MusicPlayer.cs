using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play(); // Play the song
    }

    public void StopMusic()
    {
        audioSource.Stop(); // Stop the song
    }
}
