using UnityEngine;
using UnityEngine.UI;

public class AudioManagerVolume : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioManager audioManager;

    private void Start()
    {
        // Set the initial value of the slider to match the current volume
        volumeSlider.value = audioManager.GetVolume();
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    // Set the volume of the AudioManager based on the slider value
    public void SetVolume(float volume)
    {
        audioManager.SetVolume(volume);
    }
}
