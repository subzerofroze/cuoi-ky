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
            case "Todd":
                return "Set 1 Main Game";
            case "Kurt":
                return "Set 1 Main Game";
            case "Faye":
                return "Set 1 Main Game";
            case "Brock":
                return "Set 1 Main Game";
            case "Chad":
                return "Set 1 Main Game";
            case "Thang":
                return "Set 2 MainGame";
            case "Quynh":
                return "Set 2 MainGame";
            case "Sang":
                return "Set 2 MainGame";
            case "Quy":
                return "Set 2 MainGame";
            case "Thinh":
                return "Set 2 MainGame";
            case "Bill":
                return "Set 3 MainGame";
            case "Pesteo":
                return "Set 3 MainGame";
            case "Plae":
                return "Set 3 MainGame";
            case "Ballie":
                return "Set 3 MainGame";
            case "Dolle":
                return "Set 3 MainGame";
            case "Crodile":
                return "Set 4 Main Game";
            case "Dogge":
                return "Set 4 Main Game";
            case "Foxy":
                return "Set 4 Main Game";
            case "Rabie":
                return "Set 4 Main Game";
            case "Turle":
                return "Set 4 Main Game";
            case "Spite":
                return "Set 5 Main Game";
            case "Tomie":
                return "Set 5 Main Game";
            case "Bitto":
                return "Set 5 Main Game";
            case "Salem":
                return "Set 5 Main Game";
            case "Flosp":
                return "Set 5 Main Game";
            default:
                return ""; // Return an empty string for unknown scenes
        }
    }
}
