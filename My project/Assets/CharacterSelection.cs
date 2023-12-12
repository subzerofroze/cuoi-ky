using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    public static string selectedCharacterName;

    public void SelectCharacter(string characterName)
    {
        selectedCharacterName = characterName;
        SceneManager.LoadScene("NameAndBetCoin");
    }
}
