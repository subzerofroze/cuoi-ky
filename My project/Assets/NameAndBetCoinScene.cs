using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NameAndBetCoinScene : MonoBehaviour
{
    public InputField nameInputField;

    void Start()
    {
        // Set the default character name in the input field
        nameInputField.text = CharacterSelection.selectedCharacterName;
    }

    public void ContinueToGame()
    {
        // You can add further logic here if needed
        SceneManager.LoadScene("GameScene");
    }
}
