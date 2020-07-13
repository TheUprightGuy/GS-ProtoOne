using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
    public List<GameObject> heads;
    public List<GameObject> arms;
    public List<GameObject> legs;


    //public List<SkinnedMeshRenderer> partMesh;
    private PlayerMovement pm;

    // Debug
    [Header("Testing")]
    public bool useDebugParts = false;
    public Part head;
    public Part arm;
    public Part leg;

    #region Setup
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        rb = GetComponent<Rigidbody>();
        pm = GetComponent<PlayerMovement>();
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
        SetPart(1, head);
        SetPart(1, arm);
        SetPart(1, leg);
        SetupCharacter();
    }

    // Get Character Ready
    public void SetupCharacter()
    {
        //rb.useGravity = true;

        // Head
        body.head = Object.Instantiate(body.head) as Part;
        body.head.Setup();
        body.head.SetParent(pm);
        // Arms
        body.arms = Object.Instantiate(body.arms) as Part;
        body.arms.Setup();
        body.arms.SetParent(pm);
        // Legs
        body.legs = Object.Instantiate(body.legs) as Part;
        body.legs.Setup();
        body.legs.SetParent(pm);
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
                    for (int i = 0; i < heads.Count; i++)
                    {
                        if (i == (int)_part.set)
                        {
                            heads[i].SetActive(true);
                        }
                        else
                        {
                            heads[i].SetActive(false);
                        }
                    }
                    break;
                }
                case PartType.Arms:
                {
                    body.arms = _part;
                    for (int i = 0; i < arms.Count; i++)
                    {
                        if (i == (int)_part.set)
                        {
                            arms[i].SetActive(true);
                        }
                        else
                        {
                            arms[i].SetActive(false);
                        }
                    }
                    break;
                }
                case PartType.Legs:
                {
                    body.legs = _part;
                    for (int i = 0; i < legs.Count; i++)
                    {
                        if (i == (int)_part.set)
                        {
                            legs[i].SetActive(true);
                        }
                        else
                        {
                            legs[i].SetActive(false);
                        }
                    }
                    break;
                }
            }
        }
    }

    #region AbilityUse
    public void OnAbilityHead()
    {
        if (body.head)
        {
            body.head.UseAbility();
        }
    }
    public void OnAbilityArms()
    {
        if (body.arms)
        {
            body.arms.UseAbility();
        }
    }
    public void OnAbilityLegs()
    {
        if (body.legs)
        {
            body.legs.UseAbility();
        }
    }
    #endregion AbilityUse
}
