using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTextScript : MonoBehaviour
{
    #region Setup
    private TMPro.TextMeshProUGUI text;
    private void Start()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
        text.enabled = false;
        EventHandler.instance.gameOver += GameOver;
    }

    private void OnDestroy()
    {
        EventHandler.instance.gameOver -= GameOver;
    }
    #endregion Setup

    public void GameOver(int _id)
    {
        EventHandler.instance.ToggleState(false);
        text.enabled = true;
        switch (_id)
        {
            case 1:
            {
                text.SetText("Player Two Wins!");
                break;
            }
            case 2:
            {
                text.SetText("Player One Wins!");
                break;
            }
        }

    }
}
