using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(PlayerInput))]
public class SetInput : MonoBehaviour
{
    // Start is called before the first frame update

    public bool refreshInputs = true;
    public int playerNo = 0;
    private GameObject InputHandler;
    private PlayerInput thisInput;
    void Start()
    {
        thisInput = GetComponent<PlayerInput>();
        thisInput.enabled = false;
        InputHandler = GameObject.FindGameObjectWithTag("InputController");
        if (InputHandler == null)
        {
            Debug.LogError("InputsHandler not found");
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        if (refreshInputs)
        {
            refreshInputs = false;
            pullPlayerInfo();
        }
    }

    private bool pullPlayerInfo()
    {
        InputData playerData = InputHandler.GetComponent<InputHandler>().AllPlayers[playerNo - 1];
        if (playerData.ControlScheme == "")
        {
            Debug.LogError("Player " + playerNo.ToString() + " ControlScheme not found");
            return false;
        }
        if (playerData.RegisteredDevice == null)
        {
            Debug.LogError("Player " + playerNo.ToString() + " RegisteredDevice not found");
            return false;
        }
        
        thisInput.enabled = true;
        thisInput.SwitchCurrentControlScheme(playerData.ControlScheme, playerData.RegisteredDevice);

        return true;
    }
}
