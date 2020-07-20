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
    public static InputHandler instance;

    //public PlayerInput playerControls;

    /// <summary>
        /// 0 Index indicates setting to none.
    /// </summary>
    public int QueryIndex = 0;

    public bool ControllerOnly = false;

    public bool AutoAddToEmptySlot = false;
    public InputData[] AllPlayers;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this);
        InputSystem.onEvent += QueryAnyInput;
        InputSystem.onDeviceChange += GetDeviceChange;
        LoadDefaultInputs();
    }

    // Update is called once per frame
    private void Update() {
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
                if(ControllerOnly)
                {
                    continue;
                }
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
            if(ControllerOnly)
            {
                return;
            }

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

    void GetDeviceChange(InputDevice device, InputDeviceChange change)
    {
        switch (change)
        {
            case InputDeviceChange.Added:
            {
                //Debug.Log($"Device {device} was added");

                //Controller only and device not controller, 
                //or does not want auto adding
                if (ControllerOnly && (device as Gamepad == null) ||
                    !AutoAddToEmptySlot) 
                {
                        break;
                }

                if (AutoAddToEmptySlot)
                {
                    for (int i = 0; i < AllPlayers.Length; i++)
                    {
                        if (AllPlayers[i].ControlScheme == "")
                        {
                            AllPlayers[i].RegisteredDevice = device;
                            AllPlayers[i].ControlScheme = "XboxController";
                            break;
                        }
                    }
                }
                break;
            }
            case InputDeviceChange.Removed:
            {
                //Debug.Log($"Device {device} was removed");
                for (int i = 0; i < AllPlayers.Length; i++)
                {
                    if (AllPlayers[i].RegisteredDevice == device)
                    {
                        AllPlayers[i].RegisteredDevice = null;
                        AllPlayers[i].ControlScheme = "";
                        break;
                    }
                }
                break;
            }
        }
    }
    
    
}
