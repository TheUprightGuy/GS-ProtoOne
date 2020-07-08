using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilitiesUI : MonoBehaviour
{
    public Image icon;
    public TMPro.TextMeshProUGUI text;

    public void SwitchPrefab(Part _part)
    {
        icon.sprite = _part.abilitySprite;
        text.SetText(_part.abilityText);
    }
}
