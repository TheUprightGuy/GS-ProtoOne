using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
[RequireComponent(typeof(PlayerInput))]
public class SetInput : MonoBehaviour
{
    // Start is called before the first frame update

    public bool refreshInputs = true;
    public int playerNo = 0;
    private GameObject InputHandler;
    private PlayerInput thisInput;
    private InputData LatestData;

    public bool DisableOnEmpty = false;

    public bool firstCalled = false;
    public UnityEvent OnDeviceDisconnect;
    void Start()
    {
        thisInput = GetComponent<PlayerInput>();
        thisInput.neverAutoSwitchControlSchemes = true;

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
        InputData tempData = InputHandler.GetComponent<InputHandler>().AllPlayers[playerNo - 1];

        //If input device not yet set
        if (!thisInput.enabled ||
            tempData.RegisteredDevice != LatestData.RegisteredDevice)
        {
            pullPlayerInfo();
        }

        if(tempData.ControlScheme == "") //If no control scheme
        {
            if(DisableOnEmpty)
            {
                thisInput.enabled = false;
            }

            if(!firstCalled)
            {
                OnDeviceDisconnect.Invoke();
                firstCalled = true; //Event was called
            }
        }
    }

    private bool pullPlayerInfo()
    {
        InputData playerData = InputHandler.GetComponent<InputHandler>().AllPlayers[playerNo - 1];
        if (playerData.ControlScheme == "")
        {
            //Debug.LogError("Player " + playerNo.ToString() + " ControlScheme not found");
            return false;
        }
        if (playerData.RegisteredDevice == null)
        {
            //Debug.LogError("Player " + playerNo.ToString() + " RegisteredDevice not found");
            return false;
        }
        
        thisInput.enabled = true;
        thisInput.SwitchCurrentControlScheme(playerData.ControlScheme, playerData.RegisteredDevice);
        LatestData = playerData;

        firstCalled = false; //Reset event call
        return true;
    }
}
