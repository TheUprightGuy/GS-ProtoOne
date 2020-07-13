using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionScript : MonoBehaviour
{
    public Transform p1Pos;
    public Transform p2Pos;

    private void Start()
    {
        EventHandler.instance.MoveCharacter(1, p1Pos);
        EventHandler.instance.MoveCharacter(2, p2Pos);
    }
}
