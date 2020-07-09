using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Part", menuName = "Parts", order = 1)]
public class Part : ScriptableObject
{
    [Header("Setup Fields")]
    public PartType partType;
    public Sprite sprite;
    public Sprite abilitySprite;
    public string abilityText;
    public Mesh mesh;

    [Header("Part Stats")]
    public int maxIntegrity;
}

