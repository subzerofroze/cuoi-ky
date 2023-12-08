using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSelector : MonoBehaviour
{
    public string set;

    void Start()
    {

    }

    public void OpenScene()
    {
        SceneManager.LoadScene(set.ToString());
    }
}

