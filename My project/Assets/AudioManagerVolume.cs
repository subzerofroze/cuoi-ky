using UnityEngine;
using UnityEngine.UI;

public class AudioManagerVolume : MonoBehaviour
{
    public Slider volumeSlider;
    public Toggle muteToggle; // Toggle for mute/unmute
    public AudioManager audioManager;

    private bool isMuted = true; // Flag to track mute status

    private void Start()
    {
        volumeSlider.value = audioManager.GetVolume();
        volumeSlider.onValueChanged.AddListener(SetVolume);

        // Add listener to the mute/unmute toggle
        muteToggle.onValueChanged.AddListener(SetMuteStatus);
    }

    // Set the volume of the AudioManager based on the slider value
    public void SetVolume(float volume)
    {
        if (!isMuted) // Only change volume if not muted
        {
            audioManager.SetVolume(volume);
        }
    }

    // Set the mute status based on the toggle value
    public void SetMuteStatus(bool isMuted)
    {
        this.isMuted = isMuted;
        if (isMuted)
        {
            audioManager.SetVolume(0f); // Mute by setting volume to 0
        }
        else
        {
            // Unmute by setting volume to the slider's value
            audioManager.SetVolume(volumeSlider.value);
        }
    }
}
