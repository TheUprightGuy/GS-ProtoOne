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
    void Use(PlayerMovement _player);
}

// ABILITIES

public class Charge : Ability
{
    public void Use(PlayerMovement _player)
    {
        Debug.Log("Charge");
        // As a demo
        _player.charging = true;
        _player.chargingTimer = 1.0f;
        _player.rb.AddForce(new Vector3(-1.0f, 0.0f, 0.0f) * _player.jumpThrust, ForceMode.Impulse);

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
    private LayerMask _layerMask = LayerMask.NameToLayer("Player");
    private const float MaxDistance = 10.0f;

    public void Use(PlayerMovement _player)
    {
        Debug.Log("GrappleTriggered");
        var transform = _player.transform;
        _player.transform.Translate(transform.worldToLocalMatrix.MultiplyVector(transform.forward));
        var ray = transform.worldToLocalMatrix.MultiplyVector(transform.forward);
        var position = _player.transform.position;
        bool grappleHit = Physics.Raycast (position, ray, out var hit, 10.0f);
        Debug.Log(grappleHit ? "grappleHit" : "grappleMissed");
    }
}