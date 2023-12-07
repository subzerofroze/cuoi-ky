using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.SimpleLocalization;
using Assets.SimpleLocalization.Scripts;

public class MultiLanguage : MonoBehaviour
{
    public void Language(string language)
    {
        LocalizationManager.Language = language;
        PlayerPrefs.SetString("language", language);
    }

    private void Awake()
    {
        LocalizationManager.Read();

        switch(PlayerPrefs.GetString("language"))
        {
            case "English":
                LocalizationManager.Language = "Vietnamese";
                break;

            case "Vietnamese":
                LocalizationManager.Language = "English";
                break;
        }
    }

    
}
