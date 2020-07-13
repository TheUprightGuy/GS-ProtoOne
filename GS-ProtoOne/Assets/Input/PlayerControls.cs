// GENERATED AUTOMATICALLY FROM 'Assets/Input/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""107a80e2-70da-4db4-a05e-032ef752efdb"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""f82f3609-737d-40fa-9158-2c3af6a7244e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""90a8f6f9-d621-417c-9b39-9435aa3acb49"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""936002d8-03d8-4b78-bdbb-8c5d22ee1440"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Block"",
                    ""type"": ""Button"",
                    ""id"": ""f1ff9337-5641-4e25-8a2c-cebe8b1b44b5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Punch"",
                    ""type"": ""Button"",
                    ""id"": ""3f0457d7-e84c-457d-a38b-1a7de328b3c0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Kick"",
                    ""type"": ""Button"",
                    ""id"": ""7cbdd9c0-366e-4193-b5e5-6584e8f791b6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""AbiltyLegs"",
                    ""type"": ""Button"",
                    ""id"": ""2a9ae43e-7e84-43ec-b248-be04ba6b015a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""AbiltyArms"",
                    ""type"": ""Button"",
                    ""id"": ""dd3b392d-54ed-415d-a93c-47e3581305d8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""AbilityHead"",
                    ""type"": ""Button"",
                    ""id"": ""599d9464-05e2-40ca-a55b-42a28761ffdc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6aa88f17-91a0-42a3-bec6-b77cc674180b"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XboxController"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b6bca15f-e32a-4d3e-b3a6-14c5718e56cc"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoardLeft"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d32b4e73-c628-4c07-8182-369a8a7d42b8"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoardRight"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""50576159-db9c-40bc-a634-949c988290bb"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XboxController"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0295c923-b5d4-4124-8c42-e86542e62cbe"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XboxController"",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""93bcf095-f680-4de5-9ee8-45d111c0a884"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoardLeft"",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d716dd70-772b-400f-90af-e2d4e24b7169"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoardRight"",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b3baea88-52fd-442d-b054-12064e1fd815"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XboxController"",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8c1f0060-e1bd-435a-b227-79f1eb4819c6"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": ""XboxController"",
                    ""action"": ""Block"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8536d7dd-5309-403e-b21d-d1e49a97dc0e"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": ""XboxController"",
                    ""action"": ""Punch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9c7ac1e2-5e95-417d-88a9-f61a85b91724"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": ""XboxController"",
                    ""action"": ""Kick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Axis"",
                    ""id"": ""f0f2c977-0ca0-42b9-9a4d-39c659d7ae28"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""a8b08a2b-8d35-403f-9f25-0193d615504f"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XboxController"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""f5032a91-a7b9-42ea-ac36-c57106211617"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XboxController"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Axis"",
                    ""id"": ""034851ff-d737-4998-804a-b11b68f30607"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""5bd6e4d2-ad95-401b-9cb0-ca7ce253863b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoardLeft"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""df28d795-b2b1-4086-897d-2e25c48e4602"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyBoardLeft"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""648e9622-4714-4372-8179-6fc6e43efc9c"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AbiltyLegs"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""94158ae2-e694-452e-a0ca-182133e666a1"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AbiltyArms"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cb7c8a7c-d567-4af2-93aa-b49ec55df887"",
                    ""path"": ""<DualShockGamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AbilityHead"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""XboxController"",
            ""bindingGroup"": ""XboxController"",
            ""devices"": [
                {
                    ""devicePath"": ""<XInputController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""KeyBoardLeft"",
            ""bindingGroup"": ""KeyBoardLeft"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""KeyBoardRight"",
            ""bindingGroup"": ""KeyBoardRight"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Crouch = m_Player.FindAction("Crouch", throwIfNotFound: true);
        m_Player_Block = m_Player.FindAction("Block", throwIfNotFound: true);
        m_Player_Punch = m_Player.FindAction("Punch", throwIfNotFound: true);
        m_Player_Kick = m_Player.FindAction("Kick", throwIfNotFound: true);
        m_Player_AbiltyLegs = m_Player.FindAction("AbiltyLegs", throwIfNotFound: true);
        m_Player_AbiltyArms = m_Player.FindAction("AbiltyArms", throwIfNotFound: true);
        m_Player_AbilityHead = m_Player.FindAction("AbilityHead", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Crouch;
    private readonly InputAction m_Player_Block;
    private readonly InputAction m_Player_Punch;
    private readonly InputAction m_Player_Kick;
    private readonly InputAction m_Player_AbiltyLegs;
    private readonly InputAction m_Player_AbiltyArms;
    private readonly InputAction m_Player_AbilityHead;
    public struct PlayerActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Crouch => m_Wrapper.m_Player_Crouch;
        public InputAction @Block => m_Wrapper.m_Player_Block;
        public InputAction @Punch => m_Wrapper.m_Player_Punch;
        public InputAction @Kick => m_Wrapper.m_Player_Kick;
        public InputAction @AbiltyLegs => m_Wrapper.m_Player_AbiltyLegs;
        public InputAction @AbiltyArms => m_Wrapper.m_Player_AbiltyArms;
        public InputAction @AbilityHead => m_Wrapper.m_Player_AbilityHead;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Crouch.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCrouch;
                @Block.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBlock;
                @Block.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBlock;
                @Block.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBlock;
                @Punch.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPunch;
                @Punch.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPunch;
                @Punch.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPunch;
                @Kick.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnKick;
                @Kick.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnKick;
                @Kick.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnKick;
                @AbiltyLegs.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAbiltyLegs;
                @AbiltyLegs.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAbiltyLegs;
                @AbiltyLegs.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAbiltyLegs;
                @AbiltyArms.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAbiltyArms;
                @AbiltyArms.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAbiltyArms;
                @AbiltyArms.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAbiltyArms;
                @AbilityHead.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAbilityHead;
                @AbilityHead.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAbilityHead;
                @AbilityHead.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAbilityHead;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
                @Block.started += instance.OnBlock;
                @Block.performed += instance.OnBlock;
                @Block.canceled += instance.OnBlock;
                @Punch.started += instance.OnPunch;
                @Punch.performed += instance.OnPunch;
                @Punch.canceled += instance.OnPunch;
                @Kick.started += instance.OnKick;
                @Kick.performed += instance.OnKick;
                @Kick.canceled += instance.OnKick;
                @AbiltyLegs.started += instance.OnAbiltyLegs;
                @AbiltyLegs.performed += instance.OnAbiltyLegs;
                @AbiltyLegs.canceled += instance.OnAbiltyLegs;
                @AbiltyArms.started += instance.OnAbiltyArms;
                @AbiltyArms.performed += instance.OnAbiltyArms;
                @AbiltyArms.canceled += instance.OnAbiltyArms;
                @AbilityHead.started += instance.OnAbilityHead;
                @AbilityHead.performed += instance.OnAbilityHead;
                @AbilityHead.canceled += instance.OnAbilityHead;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_XboxControllerSchemeIndex = -1;
    public InputControlScheme XboxControllerScheme
    {
        get
        {
            if (m_XboxControllerSchemeIndex == -1) m_XboxControllerSchemeIndex = asset.FindControlSchemeIndex("XboxController");
            return asset.controlSchemes[m_XboxControllerSchemeIndex];
        }
    }
    private int m_KeyBoardLeftSchemeIndex = -1;
    public InputControlScheme KeyBoardLeftScheme
    {
        get
        {
            if (m_KeyBoardLeftSchemeIndex == -1) m_KeyBoardLeftSchemeIndex = asset.FindControlSchemeIndex("KeyBoardLeft");
            return asset.controlSchemes[m_KeyBoardLeftSchemeIndex];
        }
    }
    private int m_KeyBoardRightSchemeIndex = -1;
    public InputControlScheme KeyBoardRightScheme
    {
        get
        {
            if (m_KeyBoardRightSchemeIndex == -1) m_KeyBoardRightSchemeIndex = asset.FindControlSchemeIndex("KeyBoardRight");
            return asset.controlSchemes[m_KeyBoardRightSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnBlock(InputAction.CallbackContext context);
        void OnPunch(InputAction.CallbackContext context);
        void OnKick(InputAction.CallbackContext context);
        void OnAbiltyLegs(InputAction.CallbackContext context);
        void OnAbiltyArms(InputAction.CallbackContext context);
        void OnAbilityHead(InputAction.CallbackContext context);
    }
}
