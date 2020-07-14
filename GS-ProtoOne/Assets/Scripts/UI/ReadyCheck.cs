using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// Temporary

public class ReadyCheck : MonoBehaviour
{
    [Header("Setup Fields")]
    public int id;
    // Temporary
    public string scene;
    private TMPro.TextMeshProUGUI readyText;
    private bool ready = false;
    

    #region Setup
    private void Awake()
    {
        readyText = GetComponent<TMPro.TextMeshProUGUI>();
        // Safety Check
        if (!readyText)
        {
            Debug.LogError("Text not Found!");
        }
    }


    private void Start()
    {
        EventHandler.instance.readyUp += ReadyUp;
    }
    private void OnDestroy()
    {
        EventHandler.instance.readyUp -= ReadyUp;
    }
    #endregion Setup

    // Ready Up State - Temporary Start x2 to go to Game Scene
    public void ReadyUp(int _id)
    {
        // Check Player ID
        if (_id == id)
        {
            if (ready)
            {
                // Temporary - 1p
                EventHandler.instance.SetupCharacter();
                EventHandler.instance.ChangeScene(scene);
            }
            else
            {
                ready = true;
                readyText.SetText("Ready!");
            }
        }
    }
}
