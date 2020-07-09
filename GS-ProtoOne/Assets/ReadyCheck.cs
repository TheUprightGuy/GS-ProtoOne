using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadyCheck : MonoBehaviour
{
    private TMPro.TextMeshProUGUI readyText;
    private bool ready = false;

    public int id;

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

    public void ReadyUp(int _id)
    {
        if (_id == id)
        {
            ready = !ready;
            if (ready)
            {
                readyText.SetText("Ready!");
            }
            else
            {
                readyText.SetText("Press Start to Ready");
            }
        }
    }
}
