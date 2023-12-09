using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.SimpleLocalization;
using Assets.SimpleLocalization.Scripts;

public class MultiLanguage : MonoBehaviour
{
    private void Awake()
    {
        // Read localization data
        LocalizationManager.Read();

        // Set the language based on PlayerPrefs
        string savedLanguage = PlayerPrefs.GetString("language", "English");
        LocalizationManager.Language = savedLanguage;

        // Log for debugging purposes
        Debug.Log("Current Language: " + savedLanguage);
    }

    public void Language(string language)
    {
        LocalizationManager.Language = language;
        PlayerPrefs.SetString("language", language);

        // Reload the scene to apply language changes
        ReloadAllScenes();
    }

    private void ReloadAllScenes()
    {
        int sceneCount = UnityEngine.SceneManagement.SceneManager.sceneCount;

        for (int i = 0; i < sceneCount; i++)
        {
            string sceneName = UnityEngine.SceneManagement.SceneManager.GetSceneAt(i).name;
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
    }
}

