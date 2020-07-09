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
    [Header("Setup Fields")]
    public int id;
    private Body body;
    private Rigidbody rb;
    [HideInInspector] public List<MeshFilter> partMesh;

    #region Setup
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        rb = GetComponent<Rigidbody>();

        foreach(Transform n in transform)
        {
            if (n.GetComponent<MeshFilter>())
            {
                partMesh.Add(n.GetComponent<MeshFilter>());
            }
        }
    }

    private void Start()
    {
        EventHandler.instance.selectPart += SetPart; 
        EventHandler.instance.toggleGravity += ToggleGravity;
    }
    private void OnDestroy()
    {
        EventHandler.instance.selectPart -= SetPart;
        EventHandler.instance.toggleGravity -= ToggleGravity;
    }

    #endregion Setup

    // Toggle Gravity
    public void ToggleGravity()
    {
        rb.useGravity = !rb.useGravity;
    }

    // Update Loop
    public void Update()
    {
        // Check for input
        if (Input.GetButtonDown("Start"))
        {
            // Ready Up
            EventHandler.instance.ReadyUp(id);
        }
    }

    // Set Part & Update Mesh
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
