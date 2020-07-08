using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartAbilities : MonoBehaviour
{
    public List<AbilitiesUI> abilities;

    private void Awake()
    {
        foreach(Transform n in transform)
        {
            if (n.GetComponent<AbilitiesUI>())
            {
                abilities.Add(n.GetComponent<AbilitiesUI>());
            }
        }
    }
}
