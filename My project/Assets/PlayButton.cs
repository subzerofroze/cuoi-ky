using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public CoinManager coinManager;

    public void OnClickPlayButton()
    {
        if (coinManager.currentCoins >= 5)
        {
            // Load the "Set Selection" scene
            SceneManager.LoadScene("Set Selection");
        }
        else
        {
            // Display a message or take other actions indicating that the player needs more coins
            Debug.Log("Not enough coins to play. Earn more coins!");
        }
    }
}
