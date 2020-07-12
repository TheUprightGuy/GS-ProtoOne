using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AbilityName
{
    Charge,
    Headbutt,
    Punch,
    Kick,
    Grapple,
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

public class Grapple : Ability
{
    private LayerMask _layerMask = LayerMask.NameToLayer("Player");
    private const float MaxDistance = 10.0f;

    public void Use(GameObject _player)
    {
        Debug.Log("GrappleTriggered");
       bool grappleHit = Physics.Raycast(_player.transform.position, _player.transform.right, MaxDistance, _layerMask);
       if (grappleHit)
       {
           Debug.Log("grappleHit");
       }
       else
       {
           Debug.Log("grappleMissed");
       }
    }
}