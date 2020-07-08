using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Display Container
public class PartScript : MonoBehaviour
{
    public Part part;    

    // This is a temporary setup - will probably swap to SO's to get values from in future
    // Pass through Prefab to Display
    public void SwitchPrefab(Part _part)
    {
        part = _part;
        Setup();
    }

    public void Setup()
    {
        // Safety Check
        if (part)
        {
            GetComponent<Image>().sprite = part.sprite;
        }
    }
}
