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
    }

    // Update is called once per frame
    public void QueryInputIndex(int _iIndex)
    {
        QueryIndex = _iIndex;
    }

    void QueryAnyInput(InputEventPtr eventPtr, InputDevice device)
    {
        
        // Ignore anything that isn't a state event.
        if (!eventPtr.IsA<StateEvent>() && !eventPtr.IsA<DeltaStateEvent>() || QueryIndex == 0)
            return;

        if (QueryIndex > AllPlayers.Length)
        {
            Debug.LogWarning("QueryIndex greater than player count");
        }
        var gamepad = device as Gamepad;
        var keyboard = device as Keyboard;


        if (gamepad != null)
        {
            //Debug.Log("Gamepad with ID of " + gamepad.deviceId.ToString());
            AllPlayers[QueryIndex - 1].ControlScheme = "XboxController";

            
        }
        else if (keyboard != null)
        {
            //Debug.Log("KeyBoard" );
            AllPlayers[QueryIndex - 1].ControlScheme = "KeyBoard";
        }
        else
        {
            return;
        }

        AllPlayers[QueryIndex - 1].RegisteredDevice = device;
        QueryIndex = 0;
    }


    
}
