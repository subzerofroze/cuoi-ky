using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.SetString("PreviousScene", SceneManager.GetActiveScene().name);
    }

    public void LoadPreviousScene()
    {
        string previousScene = PlayerPrefs.GetString("PreviousScene");

        if (!string.IsNullOrEmpty(previousScene))
        {
            SceneManager.LoadScene(previousScene);
        }
        else
        {
            Debug.LogWarning("Không tìm thấy scene trước đó!");
        }
    }
}
