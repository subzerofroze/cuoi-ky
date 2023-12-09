using UnityEngine;
using UnityEngine.UI;

public class ResolutionSettingsManager : MonoBehaviour
{
    public Dropdown resolutionDropdown;

    private Resolution[] resolutions;

    private void Start()
    {
        // Get all supported resolutions
        resolutions = Screen.resolutions;

        // Clear the dropdown options
        resolutionDropdown.ClearOptions();

        // Populate the dropdown with resolution options
        foreach (Resolution resolution in resolutions)
        {
            resolutionDropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));
        }

        // Set the current resolution as the default selected option
        resolutionDropdown.value = GetCurrentResolutionIndex();
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        // Set the chosen resolution
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    private int GetCurrentResolutionIndex()
    {
        // Find the index of the current resolution in the array
        Resolution currentResolution = Screen.currentResolution;
        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].width == currentResolution.width && resolutions[i].height == currentResolution.height)
            {
                return i;
            }
        }
        return 0; // Default to the first resolution if current not found
    }
}
