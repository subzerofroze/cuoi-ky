using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioManagerLogin : MonoBehaviour
{
    private static AudioManagerLogin instance;
    private AudioSource audioSource;
    private float defaultVolume = 1f; // Set your default volume here

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
            audioSource.volume = defaultVolume; // Set the default volume
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        // Check if the current scene is the Settings scene
        if (SceneManager.GetActiveScene().name == "Settings")
        {
            Destroy(gameObject); // Destroy AudioManager in the Settings scene
        }
    }

    // Play background music
    public void PlayMusic(AudioClip musicClip)
    {
        audioSource.clip = musicClip;
        audioSource.Play();
    }

    // Set volume based on the slider value
    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }

    // Get current volume
    public float GetVolume()
    {
        return audioSource.volume;
    }
}

