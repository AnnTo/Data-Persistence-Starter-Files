using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{

    public TextMeshPro NameField;
    private string name = "Noname";
    private void Start()
    {
    }

    public void StartNew()
    {

        if (NameField != null) {
            name = NameField.text;
        }
        ScoreHolder.Instance.PlayerName = name;
        ScoreHolder.Instance.PlayerScore = 0;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        ScoreHolder.Instance.SaveScore();
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }

}
