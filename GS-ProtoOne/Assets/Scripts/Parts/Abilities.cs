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
        _player.charging = true;
        _player.chargingTimer = 1.0f;
        _player.GetComponent<PlayerAnimation>().animator.SetTrigger("Charging");
        _player.GetComponent<PlayerCombat>().SwitchCraniumOn();
        //_player.rb.AddForce(new Vector3(-1.0f, 0.0f, 0.0f) * _player.jumpThrust, ForceMode.Impulse);

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

    public Grapple(GameObject grappleProjectilePrefab)
    {
        _grappleProjectilePrefab = grappleProjectilePrefab;
    }

    public void Use(PlayerMovement player)
    {
        Debug.Log("GrappleTriggered");
        var projInstance = Object.Instantiate(_grappleProjectilePrefab, player.transform);
        projInstance.GetComponent<GrappleProjectile>().SetPlayerReference(player.gameObject);
    }
}