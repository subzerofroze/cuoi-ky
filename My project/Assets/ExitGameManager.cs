using UnityEngine;

public class ExitGameManager : MonoBehaviour
{
    public void OnExitButtonClick()
    {
        // This will quit the application (works in standalone builds)
        Application.Quit();

#if UNITY_EDITOR
        // In the Unity Editor, stop playing the scene
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
