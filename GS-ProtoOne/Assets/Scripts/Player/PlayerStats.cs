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
    //[HideInInspector]
    public List<SkinnedMeshRenderer> partMesh;

    // Debug
    [Header("Testing")]
    public bool useDebugParts = false;
    public Part head;
    public Part arms;
    public Part legs;

    #region Setup
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        rb = GetComponent<Rigidbody>();

        /*foreach(Transform n in transform)
        {
            if (n.GetComponent<MeshFilter>())
            {
                partMesh.Add(n.GetComponent<MeshFilter>());
            }
        }*/
    }

    private void Start()
    {
        EventHandler.instance.selectPart += SetPart; 
        EventHandler.instance.setupCharacter += SetupCharacter;

        if (useDebugParts)
        {
            DebugToon();
        }
    }
    private void OnDestroy()
    {
        EventHandler.instance.selectPart -= SetPart;
        EventHandler.instance.setupCharacter -= SetupCharacter;
    }

    #endregion Setup

    // Debug Toon
    public void DebugToon()
    {
        SetPart(0, head);
        SetPart(0, arms);
        SetPart(0, legs);
        SetupCharacter();
    }


    // Get Character Ready
    public void SetupCharacter()
    {
        rb.useGravity = true;

        // Head
        body.head = Object.Instantiate(body.head) as Part;
        body.head.Setup();
        body.head.SetParent(this.gameObject);
        // Arms
        body.arms = Object.Instantiate(body.arms) as Part;
        body.arms.Setup();
        body.arms.SetParent(this.gameObject);
        // Legs
        body.legs = Object.Instantiate(body.legs) as Part;
        body.legs.Setup();
        body.legs.SetParent(this.gameObject);
    }

    public void OnReadyUp()
    {
        EventHandler.instance.ReadyUp(id);
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
                    partMesh[0].sharedMesh = body.head.leftMesh;
                    break;
                }
                case PartType.Arms:
                {
                    body.arms = _part;
                    partMesh[1].sharedMesh = body.arms.leftMesh;
                    partMesh[2].sharedMesh = body.arms.rightMesh;
                    break;
                }
                case PartType.Legs:
                {
                    body.legs = _part;
                    partMesh[3].sharedMesh = body.legs.leftMesh;
                    partMesh[4].sharedMesh = body.legs.rightMesh;
                    break;
                }
            }
        }
    }

    public void OnAbilityHead()
    {
        body.head.UseAbility();
    }

}
