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
}
