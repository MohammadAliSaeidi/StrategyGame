//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Presets/InputAction/StrategyGameInputAction.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @StrategyGameInputAction : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @StrategyGameInputAction()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""StrategyGameInputAction"",
    ""maps"": [
        {
            ""name"": ""InGame"",
            ""id"": ""a954a778-7f0f-4672-ad70-418a10c0d581"",
            ""actions"": [
                {
                    ""name"": ""Select"",
                    ""type"": ""Value"",
                    ""id"": ""835adcdb-febc-4623-85e3-276c40ad7c12"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Command"",
                    ""type"": ""Button"",
                    ""id"": ""3374873a-7044-4c94-94dc-434ed7b9ca51"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""2bbf7599-3889-412f-a5e6-5bb5d76c1a11"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MultipleSelection"",
                    ""type"": ""Button"",
                    ""id"": ""ee490990-ec0d-4b10-a363-fda57ddde0fa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""AttackMode"",
                    ""type"": ""Button"",
                    ""id"": ""1e676dbd-a438-4f20-a2d8-9866fc6a9bd0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""CancelCommanding"",
                    ""type"": ""Button"",
                    ""id"": ""00ce3275-d3c4-4e0e-b0bf-fce83acc2f79"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""OpenMenu"",
                    ""type"": ""Button"",
                    ""id"": ""faa99307-5740-4d3a-b7e1-5b07024c0ff8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""CameraMovement"",
                    ""type"": ""Value"",
                    ""id"": ""052daef5-0559-4c2a-a619-997526098620"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Scrolling"",
                    ""type"": ""Value"",
                    ""id"": ""e4c32693-f317-4029-b198-04be578770f3"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b6f91c36-0552-4c79-af41-d04cf1c41d67"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyboard"",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ba8c6f3e-48d2-48b2-8267-78ae1e67f274"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyboard"",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c05ecc57-3827-49d9-9901-2a3c299071d3"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyboard"",
                    ""action"": ""MultipleSelection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""da986888-794d-4669-951a-7aec514aac81"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyboard"",
                    ""action"": ""AttackMode"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7f48e2b6-ce6b-4a1d-be97-8081e0da91e9"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyboard"",
                    ""action"": ""CancelCommanding"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d1c3965e-2af7-47a3-9ecd-03b56911aa5d"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyboard"",
                    ""action"": ""OpenMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""79af832a-4001-4fa0-b71e-a074e2d32b46"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyboard"",
                    ""action"": ""Command"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""21fb3dba-268a-4a15-8b3e-2580918c0289"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""f4eb8a0f-31f2-4c21-9572-a9051057c88b"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""1c32510f-03ed-4ce4-8913-de7517dc867b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""69692b09-8a91-4b02-ae09-4b281f2e1141"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""468f21a8-c2ab-4268-847a-575279d10e8d"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""6be3fceb-d5f5-4ddc-9f8d-c8176c4689ba"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": ""Normalize(min=-1,max=1)"",
                    ""groups"": """",
                    ""action"": ""Scrolling"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""f76c7454-87c7-4fe9-b898-f78c9c2cfcac"",
                    ""path"": ""<Mouse>/scroll/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyboard"",
                    ""action"": ""Scrolling"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""08bfe449-0fa1-4054-9b8c-89a9f600e74c"",
                    ""path"": ""<Mouse>/scroll/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyboard"",
                    ""action"": ""Scrolling"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""MouseAndKeyboard"",
            ""bindingGroup"": ""MouseAndKeyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // InGame
        m_InGame = asset.FindActionMap("InGame", throwIfNotFound: true);
        m_InGame_Select = m_InGame.FindAction("Select", throwIfNotFound: true);
        m_InGame_Command = m_InGame.FindAction("Command", throwIfNotFound: true);
        m_InGame_MousePosition = m_InGame.FindAction("MousePosition", throwIfNotFound: true);
        m_InGame_MultipleSelection = m_InGame.FindAction("MultipleSelection", throwIfNotFound: true);
        m_InGame_AttackMode = m_InGame.FindAction("AttackMode", throwIfNotFound: true);
        m_InGame_CancelCommanding = m_InGame.FindAction("CancelCommanding", throwIfNotFound: true);
        m_InGame_OpenMenu = m_InGame.FindAction("OpenMenu", throwIfNotFound: true);
        m_InGame_CameraMovement = m_InGame.FindAction("CameraMovement", throwIfNotFound: true);
        m_InGame_Scrolling = m_InGame.FindAction("Scrolling", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // InGame
    private readonly InputActionMap m_InGame;
    private IInGameActions m_InGameActionsCallbackInterface;
    private readonly InputAction m_InGame_Select;
    private readonly InputAction m_InGame_Command;
    private readonly InputAction m_InGame_MousePosition;
    private readonly InputAction m_InGame_MultipleSelection;
    private readonly InputAction m_InGame_AttackMode;
    private readonly InputAction m_InGame_CancelCommanding;
    private readonly InputAction m_InGame_OpenMenu;
    private readonly InputAction m_InGame_CameraMovement;
    private readonly InputAction m_InGame_Scrolling;
    public struct InGameActions
    {
        private @StrategyGameInputAction m_Wrapper;
        public InGameActions(@StrategyGameInputAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @Select => m_Wrapper.m_InGame_Select;
        public InputAction @Command => m_Wrapper.m_InGame_Command;
        public InputAction @MousePosition => m_Wrapper.m_InGame_MousePosition;
        public InputAction @MultipleSelection => m_Wrapper.m_InGame_MultipleSelection;
        public InputAction @AttackMode => m_Wrapper.m_InGame_AttackMode;
        public InputAction @CancelCommanding => m_Wrapper.m_InGame_CancelCommanding;
        public InputAction @OpenMenu => m_Wrapper.m_InGame_OpenMenu;
        public InputAction @CameraMovement => m_Wrapper.m_InGame_CameraMovement;
        public InputAction @Scrolling => m_Wrapper.m_InGame_Scrolling;
        public InputActionMap Get() { return m_Wrapper.m_InGame; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InGameActions set) { return set.Get(); }
        public void SetCallbacks(IInGameActions instance)
        {
            if (m_Wrapper.m_InGameActionsCallbackInterface != null)
            {
                @Select.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnSelect;
                @Command.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnCommand;
                @Command.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnCommand;
                @Command.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnCommand;
                @MousePosition.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnMousePosition;
                @MultipleSelection.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnMultipleSelection;
                @MultipleSelection.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnMultipleSelection;
                @MultipleSelection.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnMultipleSelection;
                @AttackMode.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnAttackMode;
                @AttackMode.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnAttackMode;
                @AttackMode.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnAttackMode;
                @CancelCommanding.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnCancelCommanding;
                @CancelCommanding.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnCancelCommanding;
                @CancelCommanding.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnCancelCommanding;
                @OpenMenu.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnOpenMenu;
                @OpenMenu.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnOpenMenu;
                @OpenMenu.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnOpenMenu;
                @CameraMovement.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnCameraMovement;
                @CameraMovement.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnCameraMovement;
                @CameraMovement.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnCameraMovement;
                @Scrolling.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnScrolling;
                @Scrolling.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnScrolling;
                @Scrolling.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnScrolling;
            }
            m_Wrapper.m_InGameActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
                @Command.started += instance.OnCommand;
                @Command.performed += instance.OnCommand;
                @Command.canceled += instance.OnCommand;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @MultipleSelection.started += instance.OnMultipleSelection;
                @MultipleSelection.performed += instance.OnMultipleSelection;
                @MultipleSelection.canceled += instance.OnMultipleSelection;
                @AttackMode.started += instance.OnAttackMode;
                @AttackMode.performed += instance.OnAttackMode;
                @AttackMode.canceled += instance.OnAttackMode;
                @CancelCommanding.started += instance.OnCancelCommanding;
                @CancelCommanding.performed += instance.OnCancelCommanding;
                @CancelCommanding.canceled += instance.OnCancelCommanding;
                @OpenMenu.started += instance.OnOpenMenu;
                @OpenMenu.performed += instance.OnOpenMenu;
                @OpenMenu.canceled += instance.OnOpenMenu;
                @CameraMovement.started += instance.OnCameraMovement;
                @CameraMovement.performed += instance.OnCameraMovement;
                @CameraMovement.canceled += instance.OnCameraMovement;
                @Scrolling.started += instance.OnScrolling;
                @Scrolling.performed += instance.OnScrolling;
                @Scrolling.canceled += instance.OnScrolling;
            }
        }
    }
    public InGameActions @InGame => new InGameActions(this);
    private int m_MouseAndKeyboardSchemeIndex = -1;
    public InputControlScheme MouseAndKeyboardScheme
    {
        get
        {
            if (m_MouseAndKeyboardSchemeIndex == -1) m_MouseAndKeyboardSchemeIndex = asset.FindControlSchemeIndex("MouseAndKeyboard");
            return asset.controlSchemes[m_MouseAndKeyboardSchemeIndex];
        }
    }
    public interface IInGameActions
    {
        void OnSelect(InputAction.CallbackContext context);
        void OnCommand(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
        void OnMultipleSelection(InputAction.CallbackContext context);
        void OnAttackMode(InputAction.CallbackContext context);
        void OnCancelCommanding(InputAction.CallbackContext context);
        void OnOpenMenu(InputAction.CallbackContext context);
        void OnCameraMovement(InputAction.CallbackContext context);
        void OnScrolling(InputAction.CallbackContext context);
    }
}
