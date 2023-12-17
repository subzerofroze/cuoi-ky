using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;

public class VirtualCurrencyManager : MonoBehaviour
{
    public Text coinsText;
    public Text LogText;
    private int playerCoins = 0;
    private int requiredCoins = 5;
    [SerializeField] InputField bettingCoinsIF;
    [SerializeField] InputField characterNameIF;
    
    private void Start()
    {
        // Call this method when the scene loads to retrieve the player's coins
        GetPlayerCoins();
    }

    private void GetPlayerCoins()
    {
        var request = new GetUserDataRequest();

        PlayFabClientAPI.GetUserData(request, OnGetUserDataSuccess, OnError);
    }

    private void OnGetUserDataSuccess(GetUserDataResult result)
    {
        if (result.Data.TryGetValue("Coins", out UserDataRecord dataRecord) && dataRecord.Value != null)
        {
            string coinsValue = dataRecord.Value;
            playerCoins = int.Parse(coinsValue);
            UpdateCoinsDisplay();
        }
        else
        {
            // Handle missing "Coins" key
            Debug.LogWarning("Coins data not found for the player. Initializing coins to default value.");
            InitializePlayerCoins();
        }
    }

    private void InitializePlayerCoins()
    {
        playerCoins = 10; // Set a default value for coins (modify this as needed)
        UpdatePlayerCoins(); // Update PlayFab data with the default value
    }



    private void UpdateCoinsDisplay()
    {
        coinsText.text = playerCoins.ToString();
    }

    public void AddCoins(int amount)
    {
        playerCoins += amount;
        UpdatePlayerCoins();
    }

    private void UpdatePlayerCoins()
    {
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                { "Coins", playerCoins.ToString() }
            }
        };

        PlayFabClientAPI.UpdateUserData(request, OnUpdateUserDataSuccess, OnError);
    }

    private void OnUpdateUserDataSuccess(UpdateUserDataResult result)
    {
        Debug.Log("Player coins updated successfully");
        UpdateCoinsDisplay();
    }

    private void OnError(PlayFabError error)
    {
        Debug.LogError("Error getting/updating player data: " + error.GenerateErrorReport());
    }

    // Example method to use when spending coins (subtracting coins)
    public void SpendCoins(int amount)
    {
        if (playerCoins >= amount)
        {
            playerCoins -= amount;
            UpdatePlayerCoins();
        }
        else
        {
            Debug.Log("Not enough coins!");
        }
    }

    // Method to load another scene
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void PlayMainGame()
    {
        if (playerCoins >= requiredCoins)
        {
            StartMainGame();
        }
        else
        {
            Debug.Log("Player does not have enough coins to play the main game.");
            // Show a message to the player indicating insufficient coins
            // For example, display a text or a popup saying "You don't have enough coins to play the main game"
        }
    }

    private void StartMainGame()
    {
        // Load the scene for the main game
        SceneManager.LoadScene("NameAndBetCoin");
    }

    int bettingCoins;
    string characterName;
    private void Betting()
    {
        bettingCoins = int.Parse(bettingCoinsIF.text);
        characterName = characterNameIF.text;
        SpendCoins(bettingCoins);
    }

    public void SetSelection()
    {
        if (bettingCoinsIF.text != null)
        {
            SceneManager.LoadScene("Set selection");
        }
        else
        {
            Debug.Log("Enter betting coins!");
            LogText.text = "Enter betting coins";
        }
    }
}
