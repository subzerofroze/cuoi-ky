using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public Toggle soundToggle;

    void Start()
    {
        // Load the saved sound setting or set a default value
        bool savedSoundState = PlayerPrefs.GetInt("SoundState", 1) == 1;
        soundToggle.isOn = savedSoundState;

        // Apply the saved sound state
        ApplySoundState();

        // Make the GameObject persist across scenes
        DontDestroyOnLoad(gameObject);
    }

    public void OnSoundToggleValueChanged()
    {
        // Save the sound state
        PlayerPrefs.SetInt("SoundState", soundToggle.isOn ? 1 : 0);

        // Apply the new sound state
        ApplySoundState();
    }

    private void ApplySoundState()
    {
        // Get the saved sound state
        bool savedSoundState = PlayerPrefs.GetInt("SoundState", 1) == 1;

        // Turn on or off the sound based on the saved state
        AudioListener.volume = savedSoundState ? 1f : 0f;
    }
}
