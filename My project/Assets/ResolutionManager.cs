using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ResolutionManager : MonoBehaviour
{
    public Dropdown resolutionDropdown;
    public Toggle fullscreenToggle;

    private void Start()
    {
        // Populate the dropdown with resolution options
        PopulateDropdown();

        // Load the saved resolution setting or set a default value
        int savedIndex = PlayerPrefs.GetInt("ResolutionIndex", 0);
        resolutionDropdown.value = savedIndex;

        // Apply the saved resolution
        ApplyResolution();

        // Set the initial fullscreen state
        fullscreenToggle.isOn = Screen.fullScreen;
    }

    private void PopulateDropdown()
    {
        // Add resolution options to the dropdown
        resolutionDropdown.ClearOptions();

        // Add resolution options directly
        resolutionDropdown.AddOptions(new List<string> { "1920x1080", "1280x720", "960x540" }); // Add more resolutions as needed
    }

    public void OnResolutionDropdownValueChanged()
    {
        // Save the selected resolution index
        PlayerPrefs.SetInt("ResolutionIndex", resolutionDropdown.value);

        // Apply the new resolution
        ApplyResolution();
    }

    public void OnFullscreenToggleValueChanged()
    {
        // Toggle fullscreen mode
        Screen.fullScreen = fullscreenToggle.isOn;

        // If not in fullscreen, apply the selected resolution
        if (!fullscreenToggle.isOn)
        {
            ApplyResolution();
        }
    }

    private void ApplyResolution()
    {
        // Get the selected resolution from the dropdown
        string selectedResolution = resolutionDropdown.options[resolutionDropdown.value].text;

        // Parse the selected resolution string
        string[] resolutionValues = selectedResolution.Split('x');

        if (resolutionValues.Length == 2)
        {
            int width = int.Parse(resolutionValues[0]);
            int height = int.Parse(resolutionValues[1]);

            // Set the selected resolution
            Screen.SetResolution(width, height, fullscreenToggle.isOn);
        }
        else
        {
            Debug.LogError("Invalid resolution format. Use the format 'WidthxHeight', e.g., '1920x1080'.");
        }
    }
}
