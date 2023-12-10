using UnityEngine;
using UnityEngine.UI;

public class ResolutionManager : MonoBehaviour
{
    public Dropdown resolutionDropdown;

    void Start()
    {
        // Load the saved resolution setting or set a default value
        int savedIndex = PlayerPrefs.GetInt("ResolutionIndex", 0);
        resolutionDropdown.value = savedIndex;

        // Apply the saved resolution
        ApplyResolution();

        // Make the GameObject persist across scenes
        DontDestroyOnLoad(gameObject);
    }

    public void OnResolutionDropdownValueChanged()
    {
        // Save the selected resolution index
        PlayerPrefs.SetInt("ResolutionIndex", resolutionDropdown.value);

        // Apply the new resolution
        ApplyResolution();
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
            Screen.SetResolution(width, height, Screen.fullScreen);
        }
        else
        {
            Debug.LogError("Invalid resolution format. Use the format 'WidthxHeight', e.g., '1920x1080'.");
        }
    }
}
