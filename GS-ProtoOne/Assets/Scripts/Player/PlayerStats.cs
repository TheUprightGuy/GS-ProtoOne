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
    public Rigidbody rb;

    public List<MeshFilter> partMesh;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        rb = GetComponent<Rigidbody>();
    }

    public void Setup()
    {
        rb.useGravity = true;
    }

    public void Update()
    {
        if (Input.GetButtonDown("Start"))
        {
            // Ready Up
            EventHandler.instance.ReadyUp(id);
        }
    }

    public void SetPart(int _id, Part _part)
    {
        if (id == _id)
        {
            switch (_part.partType)
            {
                case PartType.Head:
                {
                    body.head = _part;
                    partMesh[0].mesh = body.head.mesh;
                    break;
                }
                case PartType.Arms:
                {
                    body.arms = _part;
                    partMesh[1].mesh = body.arms.mesh;
                    break;
                }
                case PartType.Legs:
                {
                    body.legs = _part;
                    partMesh[2].mesh = body.legs.mesh;
                    break;
                }
            }
        }
    }

}
