using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Set
{
    Human,
    Frog,
    Robot
}

[CreateAssetMenu(fileName = "Part", menuName = "Parts", order = 1)]
public class Part : ScriptableObject
{
    [Header("Setup Fields")]
    public PartType partType;
    public Sprite sprite;
    public Sprite abilitySprite;
    public string abilityText;
    public Set set;
    public Ability ability;
    public AbilityName abilityName;
    [HideInInspector] public PlayerMovement player;
    [Header("Part Stats")]
    public int maxIntegrity;
    public float cooldown;
    [HideInInspector] public float cooldownTimer;

    public void UpdateCooldowns(float _deltaTime)
    {
        cooldownTimer -= _deltaTime;
    }

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
        if (cooldownTimer <= 0)
        {
            ability.Use(player);
            cooldownTimer = cooldown;
        }
    }
}

