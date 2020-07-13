using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Enum for Part Slot
public enum PartType
{
    Head = 0,
    Arms,
    Legs
}

public class PartPicker : MonoBehaviour
{
    [Header("Player ID")]
    public int id;

    [Header("Part Lists")]
    public List<Part> Head;
    public List<Part> Arms;
    public List<Part> Legs;
    // Actual List to Work from
    [HideInInspector] public List<List<Part>> partList;

    // Navigation
    private PartType currentType = 0;
    private int currentSelected = 0;
    [Header("UI Elements")]
    public PartScript partDisplayed;
    public TMPro.TextMeshProUGUI typeText;
    public AbilitiesUI ability;

    #region Setup
    public void Awake()
    {
        // Setup working ParkList
        partList = new List<List<Part>>();
        partList.Add(Head);
        partList.Add(Arms);
        partList.Add(Legs);

        // Setup all Parts
        foreach (List<Part> list in partList)
        {
            foreach (Part part in list)
            {
                part.Setup();
            }
        }
    }

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
        ability.SwitchPrefab(partList[(int)currentType][currentSelected]);
    }

    #endregion Setup

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
        ability.SwitchPrefab(partList[(int)currentType][currentSelected]);
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
        ability.SwitchPrefab(partList[(int)currentType][currentSelected]);
    }
    // Go to Next Type
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
        ability.SwitchPrefab(partList[(int)currentType][currentSelected]);
    }
    // Go to Previous Type
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
        ability.SwitchPrefab(partList[(int)currentType][currentSelected]);
    }

    // Set Part for Player
    public void SelectPart()
    {
        EventHandler.instance.SelectPart(id, partList[(int)currentType][currentSelected]);
    }
}
