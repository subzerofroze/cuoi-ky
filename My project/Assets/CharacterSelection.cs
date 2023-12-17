using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    // Function to transition to the next scene based on the current scene
    public void GoToNextScene(string currentScene)
    {
        string nextScene = GetNextScene(currentScene);

        if (!string.IsNullOrEmpty(nextScene))
        {
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            Debug.LogError("Next scene not found for " + currentScene);
        }
    }

    // Function to determine the next scene based on the current scene
    private string GetNextScene(string currentScene)
    {
        switch (currentScene)
        {
            case "Set 1":
                return "Set 1 Main Game";
            case "Set 2":
                return "Set 2 Main Game";
            case "Set 3":
                return "Set 3 Main Game";
            case "Set 4":
                return "Set 4 Main Game";
            case "Set 5":
                return "Set 5 Main Game";
            default:
                return ""; // Return an empty string for unknown scenes
        }
    }
}
