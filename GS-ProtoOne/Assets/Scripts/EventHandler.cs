using System;
using System.Collections;
using System.Collections.Generic;
using Audio;
using UnityEngine;
// Move this to event handler in future
using UnityEngine.SceneManagement;

public class EventHandler : MonoBehaviour
{
    #region Singleton
    public static EventHandler instance;
    private Animator animator;
    private string sceneToLoad;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one EventHandler exists!");
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        animator = GetComponent<Animator>();
    }
    #endregion Singleton

    // Start Button is Pressed
    public event Action<int> readyUp;
    public void ReadyUp(int _id)
    {
        if (readyUp != null)
        {
            readyUp(_id);
            AudioManager.Instance.PlaySound("ui");
        }
    }

    // Part is Selected
    public event Action<int, Part> selectPart;
    public void SelectPart(int _id, Part _part)
    {
        if (selectPart != null)
        {
            selectPart(_id, _part);
            AudioManager.Instance.PlaySound("ui");
        }
    }

    // Setup Players - Temporary Setup
    public event Action setupCharacter;
    public void SetupCharacter()
    {
        if (setupCharacter != null)
        {
            setupCharacter();
            AudioManager.Instance.PlaySound("ui");
        }
    }

    // Move Player Characters
    public event Action<int, Transform> moveCharacter;
    public void MoveCharacter(int _id, Transform _pos)
    {
        if (moveCharacter != null)
        {
            moveCharacter(_id, _pos);
        }
    }

    // Update HealthBars
    public event Action<int, float> updateHealth;
    public void UpdateHealth(int _id, float _health)
    {
        if (updateHealth != null)
        {
            updateHealth(_id, _health);
        }
    }

    // Callback to End Scene
    public event Action<int> gameOver;
    public void GameOver(int _id)
    {
        if (gameOver != null)
        {
            gameOver(_id);
        }
    }

    // Turn off Controls on Player Characters
    public event Action<bool> toggleState;
    public void ToggleState(bool _state)
    {
        if (toggleState != null)
        {
            toggleState(_state);
        }
    }

    // Scene Manager
    public void ChangeScene(string _scene)
    {
        animator.SetTrigger("FadeOut");
        AudioManager.Instance.PlaySound("ui");
        sceneToLoad = _scene;
    }

    public void ChangeSceneFunc()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad);
        animator.SetTrigger("FadeIn");
    }
    public void QuitApplication()
    {
        AudioManager.Instance.PlaySound("ui");
        Application.Quit();
    }
}
