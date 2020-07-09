using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void LoadCustomisationScene(string sceneName)
    {
        AudioManager.Instance.PlaySound("hit");
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
    
    public void QuitApplication()
    {
        Application.Quit();
    }
}
