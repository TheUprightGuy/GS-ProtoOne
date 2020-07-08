using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    [SerializeField] private string customisationSceneName = "DefaultTransitionScene";
    public void LoadCustomisationScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(customisationSceneName);
    }
    
    public void QuitApplication()
    {
        Application.Quit();
    }
}
