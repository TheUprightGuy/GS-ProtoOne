using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Move this to event handler in future
using UnityEngine.SceneManagement;

public enum PartType
{
    Head = 0,
    Arms,
    Legs
}

public class PartPicker : MonoBehaviour
{
    public PlayerStats player;

    // Part Lists for Easy Reading
    public List<Part> Head;
    public List<Part> Arms;
    public List<Part> Legs;
    // Actual List to Work from
    public List<List<Part>> partList;
  
    public void Awake()
    {
        partList = new List<List<Part>>();

        partList.Add(Head);
        partList.Add(Arms);
        partList.Add(Legs);
    }

    // Current Part Type
    public PartType currentType = 0;
    // Reference to Display Part
    public PartScript partDisplayed;
    // Reference to Header Text
    public TMPro.TextMeshProUGUI typeText;
    // Tracking
    public int currentSelected = 0;
    // AbilityUI References
    public PartAbilities abilities;

    private void Start()
    {
        // Safety Checks
        if (partDisplayed && partList[(int)currentType][currentSelected])
        {
            partDisplayed.SwitchPrefab(partList[(int)currentType][currentSelected]);
        }
        else
        {
            Debug.LogError("No Head Parts Available!");
        }
        // Set Header
        typeText.SetText(currentType.ToString());
        for (int i = 0; i < partList.Count; i++)
        {
            abilities.abilities[i].SwitchPrefab(partList[i][0]);
        }
    }

    // Go to Next Part
    public void NextPart()
    {
        // At End - Loop to Start
        if (currentSelected + 1 >= partList[(int)currentType].Count)
        {
            currentSelected = 0;
        }
        // Move Forward One
        else
        {
            currentSelected++;
        }
        // Swap SO
        partDisplayed.SwitchPrefab(partList[(int)currentType][currentSelected]);
        abilities.abilities[(int)currentType].SwitchPrefab(partList[(int)currentType][currentSelected]);
    }
    // Go to Previous Part
    public void PreviousPart()
    {
        // At Start - Loop to End
        if (currentSelected <= 0)
        {
            currentSelected = partList[(int)currentType].Count - 1;
        }
        // Move Back One
        else
        {
            currentSelected--;
        }
        // Swap SO
        partDisplayed.SwitchPrefab(partList[(int)currentType][currentSelected]);
        abilities.abilities[(int)currentType].SwitchPrefab(partList[(int)currentType][currentSelected]);
    }

    public void NextType()
    {
        // At End - Loop to Start
        if ((int)currentType + 1 >= partList.Count)
        {
            currentType = 0;
        }
        // Move Forward One
        else
        {
            currentType++;
        }
        // Reset Selection to avoid Out of Bounds
        currentSelected = 0;
        // Swap SO
        partDisplayed.SwitchPrefab(partList[(int)currentType][currentSelected]);
        // Set Header
        typeText.SetText(currentType.ToString());
        abilities.abilities[(int)currentType].SwitchPrefab(partList[(int)currentType][currentSelected]);
    }
    // Go to Previous Part
    public void PreviousType()
    {
        // At Start - Loop to End
        if ((int)currentType <= 0)
        {
            currentType = (PartType)partList.Count - 1;
        }
        // Move Back One
        else
        {
            currentType--;
        }
        // Reset Selection to avoid Out of Bounds
        currentSelected = 0;
        // Swap SO
        partDisplayed.SwitchPrefab(partList[(int)currentType][currentSelected]);
        // Set Header
        typeText.SetText(currentType.ToString());
        abilities.abilities[(int)currentType].SwitchPrefab(partList[(int)currentType][currentSelected]);
    }

    // Save Body and Continue
    public void ReadyUp()
    {
        // Add in Save Selections or w.e
        player.body.head = partList[0][0];
        player.body.arms = partList[1][0];
        player.body.legs = partList[2][0];

        player.Setup();

        SceneManager.LoadScene("GameplayScene");
    }
}
