using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public int startingCoins = 5;
    public int currentCoins;

    public Text coinText; // Reference to the UI Text element
    public GameObject player; // Reference to the player GameObject or player controller script

    void Start()
    {
        currentCoins = PlayerPrefs.GetInt("PlayerCoins", startingCoins);
        UpdateUI();
        CheckMainGameAccess();
    }

    void UpdateUI()
    {
        Debug.Log("Current Coins: " + currentCoins);
        coinText.text = currentCoins.ToString();
    }

    void CheckMainGameAccess()
    {
        if (currentCoins < 5)
        {
            DisablePlayerControls();
        }
        else
        {
            EnablePlayerControls();
            // Enable the Play button
        }
    }

    void DisablePlayerControls()
    {
        // You can disable player movement, shooting, or other controls here
        player.SetActive(false);
    }

    void EnablePlayerControls()
    {
        // You can enable player controls here
        player.SetActive(true);
    }

    public void AddCoins(int amount)
    {
        currentCoins += amount;
        UpdateUI();

        // Save the updated coin count
        PlayerPrefs.SetInt("PlayerCoins", currentCoins);
        PlayerPrefs.Save();

        CheckMainGameAccess(); // Check main game access after updating coins
    }

    public void RemoveCoins(int amount)
    {
        if (currentCoins >= amount)
        {
            currentCoins -= amount;
            UpdateUI();

            // Save the updated coin count
            PlayerPrefs.SetInt("PlayerCoins", currentCoins);
            PlayerPrefs.Save();

            CheckMainGameAccess(); // Check main game access after updating coins
        }
        else
        {
            // Handle insufficient coins
            Debug.LogWarning("Not enough coins!");
        }
    }
}
