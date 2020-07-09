using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Move this to event handler in future
using UnityEngine.SceneManagement;

public class EventHandler : MonoBehaviour
{
    #region Singleton
    public static EventHandler instance;
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
    }
    #endregion Singleton

    // Start Button is Pressed
    public event Action<int> readyUp;
    public void ReadyUp(int _id)
    {
        if (readyUp != null)
        {
            readyUp(_id);
        }
    }

    // Part is Selected
    public event Action<int, Part> selectPart;
    public void SelectPart(int _id, Part _part)
    {
        if (selectPart != null)
        {
            selectPart(_id, _part);
        }
    }

    // Setup Players - Temporary Setup
    public event Action setupCharacter;
    public void SetupCharacter()
    {
        if (setupCharacter != null)
        {
            setupCharacter();
        }
    }
}
