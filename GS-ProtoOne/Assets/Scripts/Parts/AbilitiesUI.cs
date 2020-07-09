using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilitiesUI : MonoBehaviour
{
    [Header("Setup Fields")]
    public Image icon;
    public TMPro.TextMeshProUGUI text;

    // Updates UI for Part
    public void SwitchPrefab(Part _part)
    {
        icon.sprite = _part.abilitySprite;
        text.SetText(_part.abilityText);
        // Add in Stats
    }
}
