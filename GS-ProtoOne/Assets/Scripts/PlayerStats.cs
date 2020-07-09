using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Body
{
    public Part head;
    public Part arms;
    public Part legs;
}

public class PlayerStats : MonoBehaviour
{
    public Body body;
    public int id;

    // Just for Debugging atm - check its working
    public Part head;
    public Part arms;
    public Part legs;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void Setup()
    {
        head = body.head;
        arms = body.arms;
        legs = body.legs;
    }

    public void Update()
    {
        if (Input.GetButtonDown("Start"))
        {
            // Ready Up
            EventHandler.instance.ReadyUp(id);
        }
    }
}
