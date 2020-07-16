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
    // Storage for new Part System
    public List<GameObject> heads;
    public List<GameObject> arms;
    public List<GameObject> legs;
    public float abilityCooldown = 1.0f;
    private float _abilityTimer = 0.0f;
    // Enable/Disable for Scenes
    private PlayerMovement pm;
    private PlayerAnimation pa;

    [Header("Stats")]
    public float health;
    public float maxHealth;

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
        pm = GetComponent<PlayerMovement>();
        pa = GetComponent<PlayerAnimation>();
    }

    private void Start()
    {
        EventHandler.instance.selectPart += SetPart; 
        EventHandler.instance.setupCharacter += SetupCharacter;
        EventHandler.instance.moveCharacter += MoveCharacter;
        EventHandler.instance.toggleState += ToggleState;
        EventHandler.instance.resetCharacters += ResetCharacter;

        SetPart(id, head);
        SetPart(id, arm);
        SetPart(id, leg);

        if (useDebugParts)
        {
            DebugToon();
        }
    }
    private void OnDestroy()
    {
        EventHandler.instance.selectPart -= SetPart;
        EventHandler.instance.setupCharacter -= SetupCharacter;
        EventHandler.instance.moveCharacter -= MoveCharacter;
        EventHandler.instance.toggleState -= ToggleState;
        EventHandler.instance.resetCharacters -= ResetCharacter;
    }
    #endregion Setup

    #region CharacterSetupScreen
    // Debug Toon
    public void DebugToon()
    {
        SetupCharacter();
    }

    // Get Character Ready
    public void SetupCharacter()
    {
        //ToggleState(true);

        // Head
        body.head = Object.Instantiate(body.head) as Part;
        body.head.Setup();
        body.head.SetParent(pm);
        maxHealth += body.head.maxIntegrity;
        // Arms
        body.arms = Object.Instantiate(body.arms) as Part;
        body.arms.Setup();
        body.arms.SetParent(pm);
        maxHealth += body.arms.maxIntegrity;
        // Legs
        body.legs = Object.Instantiate(body.legs) as Part;
        body.legs.Setup();
        body.legs.SetParent(pm);
        maxHealth += body.legs.maxIntegrity;

        health = maxHealth;
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
    // Ready Up in Lobby
    public void OnReadyUp()
    {
        EventHandler.instance.ReadyUp(id);
    }
    // Callback -> Moves Character to Location & Rotation
    public void MoveCharacter(int _id, Transform _pos)
    {
        if (id == _id)
        {
            transform.position = _pos.position;
            transform.rotation = _pos.rotation;
        }
    }
    #endregion CharacterSetupScreen

    private void Update()
    {
        if (health <= 0.0f)
        {
            EventHandler.instance.GameOver(id);
            health = 10000.0f;
        }

        body.head.UpdateCooldowns(Time.deltaTime);
        body.arms.UpdateCooldowns(Time.deltaTime);
        body.legs.UpdateCooldowns(Time.deltaTime);
    }

    // Up on D-Pad to Test
    public void OnDebugDamage()
    {
        TakeDamage(10.0f);
    }

    // Generic Take Damage Event
    public void TakeDamage(float _damage)
    {
        pa.Hit();
        health -= _damage;
        EventHandler.instance.UpdateHealth(id, health / maxHealth);
    }

    public void ToggleState(bool _state)
    {
        pm.active = _state;
        pa.active = _state;
    }


    public void ResetCharacter()
    {
        health = maxHealth;
        //ToggleState(true);
    }


    #region AbilityUse
    
    public void OnAbilityHead()
    {
        if (!body.head) return;
        body.head.UseAbility();
    }
    public void OnAbilityArms()
    {
        if (!body.arms) return;
        body.arms.UseAbility();
    }
    public void OnAbilityLegs()
    {
        if (!body.legs) return;
        body.legs.UseAbility();
    }
    #endregion AbilityUse
}
