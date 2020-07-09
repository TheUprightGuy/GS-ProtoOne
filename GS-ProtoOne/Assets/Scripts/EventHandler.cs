using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Move this to event handler in future
using UnityEngine.SceneManagement;

public class EventHandler : MonoBehaviour
{
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

    public PartPicker pp1;
    public PartPicker pp2;


    private void Update()
    {

    }


    // Start Button is Pressed
    public event Action<int> readyUp;
    public void ReadyUp(int _id)
    {
        if (readyUp != null)
        {
            readyUp(_id);
        }
    }

    public event Action setupPlayers;
    public void SetupPlayers()
    {
        if (setupPlayers != null)
        {
            setupPlayers();
        }
    }
}
