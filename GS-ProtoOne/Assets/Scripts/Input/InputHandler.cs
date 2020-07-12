using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.InputSystem.LowLevel;

[System.Serializable]
public struct InputData
{
    public string ControlScheme;
    public InputDevice RegisteredDevice; 
}

public class InputHandler : MonoBehaviour
{
    //public PlayerInput playerControls;

    /// <summary>
        /// 0 Index indicates setting to none.
    /// </summary>
    public int QueryIndex = 0;

    public InputData[] AllPlayers;
    void Awake()
    {
        DontDestroyOnLoad(this);
        InputSystem.onEvent += QueryAnyInput;

        LoadDefaultInputs();
    }

    // Update is called once per frame
    public void QueryInputIndex(int _iIndex)
    {
        QueryIndex = _iIndex;
    }

    void LoadDefaultInputs()
    {
        int iPlayerIndex = 0;
        string scheme;
        foreach (InputDevice item in InputSystem.devices)
        {

            if ((item as Gamepad) != null)
            {
                scheme = "XboxController";
            }
            else if ((item as Keyboard) != null)
            {
                scheme = "KeyBoardLeft";
            }
            else
            {
                continue;
            }

            AllPlayers[iPlayerIndex].ControlScheme = scheme;
            AllPlayers[iPlayerIndex].RegisteredDevice = item;

            iPlayerIndex++;
            if (iPlayerIndex >= AllPlayers.Length)
            {
                break;
            }
        }
    }

    void QueryAnyInput(InputEventPtr eventPtr, InputDevice device)
    {
        // Ignore anything that isn't a state event.
        if (!eventPtr.IsA<StateEvent>() && !eventPtr.IsA<DeltaStateEvent>() || QueryIndex == 0)
            return;

        if (QueryIndex > AllPlayers.Length)
        {
            //Debug.LogWarning("QueryIndex greater than player count");
        }

        var gamepad = device as Gamepad;
        var keyboard = device as Keyboard;

        string scheme;

        if (gamepad != null)
        {
            //Debug.Log("Gamepad with ID of " + gamepad.deviceId.ToString());
            scheme = "XboxController";
        }
        else if (keyboard != null)
        {
            //Debug.Log("KeyBoard" );
            scheme = "KeyBoardLeft";
        }
        else
        {
            return;
        }

        AllPlayers[QueryIndex - 1].ControlScheme = scheme;
        AllPlayers[QueryIndex - 1].RegisteredDevice = device;

        for (int i = 0; i < AllPlayers.Length; i++)
        {
            if (device == AllPlayers[i].RegisteredDevice && 
                (QueryIndex - 1) != i)
            {
                AllPlayers[i].RegisteredDevice = null;
                AllPlayers[i].ControlScheme = "";
            }
            
        }

        QueryIndex = 0;
    }


    
}
