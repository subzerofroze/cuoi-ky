using UnityEngine;

public class ReturnButtonScript : MonoBehaviour
{
    public void OnReturnButtonClick()
    {
        SceneManagement.instance.LoadPreviousScene();
    }
}
