using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundUIScript : MonoBehaviour
{
    public int id;

    private Image[] rounds;
    private bool[] winLoss;

    private void Start()
    {
        rounds = new Image[GetComponentsInChildren<Image>().Length];
        winLoss = new bool[GetComponentsInChildren<Image>().Length];
        rounds = GetComponentsInChildren<Image>();

        SetWins();

        EventHandler.instance.updateRounds += WinRound;
    }

    private void OnDestroy()
    {
        EventHandler.instance.updateRounds -= WinRound;
    }


    public void WinRound()
    {
        for (int i = 0; i < rounds.Length; i++)
        {
            if (winLoss[i] == false)
            {
                winLoss[i] = true;
                rounds[i].color = Color.grey;
            }
        }
    }

    public void SetWins()
    {
        int wins;
        if (id == 1)
        {
            wins = EventHandler.instance.p1Wins;
        }
        else
        {
            wins = EventHandler.instance.p2Wins;
        }

        for (int i = 0; i < wins; i++)
        {
            if (winLoss[i] == false)
            {
                winLoss[i] = true;
                rounds[i].color = Color.grey;
            }
        }
    }
}
