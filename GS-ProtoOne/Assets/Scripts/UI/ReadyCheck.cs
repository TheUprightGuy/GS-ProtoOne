using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// Temporary

public class ReadyCheck : MonoBehaviour
{
    [Header("Setup Fields")]
    public int id;
    private TMPro.TextMeshProUGUI readyText;
    
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
            if (id == 1)
            {
                EventHandler.instance.p1Ready = true;
            }
            else
            {
                EventHandler.instance.p2Ready = true;
            }
            readyText.SetText("Ready!");
        }
    }
}
