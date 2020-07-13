﻿using System;
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
    public Mesh leftMesh;
    public Mesh rightMesh;
    public Ability ability;
    public AbilityName abilityName;
    [HideInInspector] public PlayerMovement player;
    [Header("Part Stats")]
    public int maxIntegrity;

    public void Setup()
    {
        switch(abilityName)
        {
            case AbilityName.Charge:
            {
                ability = new Charge();
                break;
            }
            case AbilityName.Headbutt:
            {
                ability = new Headbutt();
                break;
            }
            case AbilityName.Punch:
            {
                ability = new Punch();
                break;
            }
            case AbilityName.Kick:
            {
                ability = new Kick();
                break;
            }
            case AbilityName.Grapple:
            {
                ability = new Grapple();
                break;
            }
        }
    }

    public void SetParent(PlayerMovement _player)
    {
        player = _player;
    }

    public void UseAbility()
    {
        ability.Use(player);
    }
}

