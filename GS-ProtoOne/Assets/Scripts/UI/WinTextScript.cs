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
        int p1Wins = EventHandler.instance.p1Wins;
        int p2Wins = EventHandler.instance.p1Wins;
        int rounds = EventHandler.instance.rounds;

        EventHandler.instance.ToggleState(false);
        text.enabled = true;
        switch (_id)
        {
            case 1:
            {
                p2Wins++;
                text.SetText("Player Two Wins!");
                break;
            }
            case 2:
            {
                p1Wins++;
                text.SetText("Player One Wins!");
                break;
            }
        }

        if (p1Wins > Mathf.Floor(rounds/2) || p2Wins > Mathf.Floor(rounds / 2))
        {
            EventHandler.instance.ChangeScene("WaydsScene");
        }
        else
        {
            EventHandler.instance.ResetScene();
        }
    }
}
