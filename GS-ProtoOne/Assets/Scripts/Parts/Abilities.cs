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
    void Use();
}

// ABILITIES

public class Charge : Ability
{
    public void Use()
    {
        Debug.Log("Charge");
    }
}

public class Headbutt : Ability
{
    public void Use()
    {
        Debug.Log("Headbutt");
    }
}

public class Punch : Ability
{
    public void Use()
    {
        Debug.Log("Punch");
    }
}

public class Kick : Ability
{
    public void Use()
    {
        Debug.Log("Kick");
    }
}