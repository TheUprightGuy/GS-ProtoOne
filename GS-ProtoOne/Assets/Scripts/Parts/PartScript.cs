using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Display Container
public class PartScript : MonoBehaviour
{
    [HideInInspector] public Part part;    

    // Pass through Prefab to Display
    public void SwitchPrefab(Part _part)
    {
        part = _part;        
        // Safety Check
        if (part)
        {
            GetComponent<Image>().sprite = part.sprite;
        }
    }
}
