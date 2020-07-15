using System.Collections;
using System.Collections.Generic;
using Parts;
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
    void Use(PlayerMovement _player);
}

// ABILITIES

public class Charge : Ability
{
    public void Use(PlayerMovement _player)
    {
        Debug.Log("Charge");
        // As a demo
        _player.rb.AddForce((-_player.transform.right) * _player.jumpThrust, ForceMode.Impulse);

    }
}

public class Headbutt : Ability
{
    public void Use(PlayerMovement _player)
    {
        Debug.Log("Headbutt");
    }
}

public class Punch : Ability
{
    public void Use(PlayerMovement _player)
    {
        Debug.Log("Punch");
    }
}

public class Kick : Ability
{
    public void Use(PlayerMovement _player)
    {
        Debug.Log("Kick");
    }
}

public class Grapple : Ability
{
    private readonly GameObject _grappleProjectilePrefab;
    private LineRenderer _lineRenderer;

    private GameObject _projInstance;
    private GameObject _player;

    public Grapple(GameObject grappleProjectilePrefab)
    {
        _lineRenderer = new LineRenderer();
        _grappleProjectilePrefab = grappleProjectilePrefab;
    }

    public void Use(PlayerMovement player)
    {
        Debug.Log("GrappleTriggered");
        _projInstance = Object.Instantiate(_grappleProjectilePrefab, player.transform);
        _player = player.gameObject;
    }
}