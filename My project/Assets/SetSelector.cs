using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetSelector : MonoBehaviour
{
    public int set;

    void Start()
    {
        
    }

    public void OpenScene()
    {
        SceneManager.LoadScene("Set " + set.ToString());
    }
}
