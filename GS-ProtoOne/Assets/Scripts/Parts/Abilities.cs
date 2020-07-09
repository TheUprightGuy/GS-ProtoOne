using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AbilityName
{
    Charge,
    Headbutt,
    Punch,
    Kick
}

// Base Ability
public interface Ability
{
    void Use(GameObject _player);
}

// ABILITIES

public class Charge : Ability
{
    public void Use(GameObject _player)
    {
        Debug.Log("Charge");
        // As a demo
        _player.transform.Translate(new Vector3(500, 0, 0));
    }
}

public class Headbutt : Ability
{
    public void Use(GameObject _player)
    {
        Debug.Log("Headbutt");
    }
}

public class Punch : Ability
{
    public void Use(GameObject _player)
    {
        Debug.Log("Punch");
    }
}

public class Kick : Ability
{
    public void Use(GameObject _player)
    {
        Debug.Log("Kick");
    }
}