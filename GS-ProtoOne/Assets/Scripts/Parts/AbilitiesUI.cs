using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilitiesUI : MonoBehaviour
{
    [Header("Setup Fields")]
    public TMPro.TextMeshProUGUI text;
    public TMPro.TextMeshProUGUI implementedText;

    // Updates UI for Part
    public void SwitchPrefab(Part _part)
    {
        text.SetText(_part.abilityText);
        implementedText.enabled = !_part.implemented;
        // Add in Stats
    }
}
