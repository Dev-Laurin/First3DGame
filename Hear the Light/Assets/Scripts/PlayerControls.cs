// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControls.inputactions'

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
            ""name"": ""Land"",
            ""id"": ""9ad635ba-55a9-4ee7-835b-f86dd45bca59"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""67af8a29-62d3-4d9b-a191-865b4fa84fc2"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveCamera"",
                    ""type"": ""Value"",
                    ""id"": ""4fcb2e00-cf1f-487b-97de-f58bef2e690e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""e06ff5be-617d-4b04-834a-0c3fe534c788"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Movement"",
                    ""id"": ""d20df922-b537-4dc1-af98-bd75fec1016c"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""a9e464e9-abe5-4396-9373-2c8aa866f4b3"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""281072b8-5512-4998-8d92-77853c970d0f"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ae79515c-2e27-487a-ae97-39b11ad13f97"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c58e5f03-08b5-407d-9fee-e5aeedeedd61"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""72d9734e-9bcc-419d-ae95-1c3ae6d8707b"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""9faae76c-8c23-41bd-babf-8aaf3235a033"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9ee8e437-4053-4187-9f0f-b454ab4906ac"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""9c7e5305-90bc-4db5-be4d-e9b1ff2bedf8"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""833a8c22-7d65-4d77-898f-17add93ac166"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Movement"",
                    ""id"": ""b6eda796-8f47-45ed-a247-76ffd1bf0155"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCamera"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c5d7a285-bd89-40a3-ba60-b52087077430"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""0a7e72d5-2138-44e0-9200-f98e0b48ad3d"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""778c1088-ffe0-431c-92eb-88bf324c016f"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f405ffad-5485-46a6-a261-99fb12ee9b88"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""af204073-d5d3-42e7-ac30-cfb8a6f04ee5"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Interaction"",
            ""id"": ""c2ef8beb-7e48-457c-9eb6-8bc4b76e526d"",
            ""actions"": [
                {
                    ""name"": ""SelectObj"",
                    ""type"": ""Button"",
                    ""id"": ""eebe78d6-cd61-4d9c-9583-942105f5445a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""OpenWeaponQuickInventory"",
                    ""type"": ""Button"",
                    ""id"": ""139bcf67-d64b-4032-92c7-0d9561c08434"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""ChooseQuickInventory"",
                    ""type"": ""Value"",
                    ""id"": ""26340202-f08f-453d-bcfc-7fd740d72960"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""OpenShieldQuickInventory"",
                    ""type"": ""Button"",
                    ""id"": ""cbbdec2e-3e93-4b2d-8826-6d7312c74cf9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""OpenBowQuickInventory"",
                    ""type"": ""Button"",
                    ""id"": ""d3ee7f4a-be64-4b9b-96c0-0cfbc2927edb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""OpenArrowQuickInventory"",
                    ""type"": ""Button"",
                    ""id"": ""19d31b21-bd5f-4b2b-87c3-21761e411e8f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""762920a4-50bd-40ce-bdde-70dd5066b160"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectObj"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""395e20fb-2a88-407e-8cb0-d12765b32fea"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectObj"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3cfbfeda-06e3-4070-89f0-ec55542c1905"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenWeaponQuickInventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9a967765-492d-40c3-9a32-0d9e0ff90ba6"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenWeaponQuickInventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector - Keyboard"",
                    ""id"": ""bafecbea-1daf-4e7c-b126-49c9ebf18c03"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChooseQuickInventory"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""7fd00300-f9c0-4f51-89b6-9bf48cd0112c"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChooseQuickInventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f6ba900a-12f1-4d0f-844c-4e5aa675dcf0"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChooseQuickInventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""80fea033-099a-4bf2-8f54-17838e533ec6"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChooseQuickInventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""096c508a-6177-42b3-bff2-e61d4a7099bc"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChooseQuickInventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector - Joystick"",
                    ""id"": ""0bc4fa42-ef63-41c1-a381-a5369af18d7e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChooseQuickInventory"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d76480bb-db00-46bf-a6a8-5d094ce87493"",
                    ""path"": ""<Joystick>/stick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChooseQuickInventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""787d648a-9386-413a-9145-8b56d99e7aca"",
                    ""path"": ""<Joystick>/stick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChooseQuickInventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ea5ba180-2349-494a-9e5d-a49c57a13460"",
                    ""path"": ""<Joystick>/stick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChooseQuickInventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""8307856c-f82e-4f31-9515-db71108f7b61"",
                    ""path"": ""<Joystick>/stick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChooseQuickInventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector - Gamepad"",
                    ""id"": ""288197ce-949c-422e-82da-7fb9a54c9d4a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChooseQuickInventory"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e6e7a0f1-1ecd-45fe-b239-0a99ccc33a37"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChooseQuickInventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""fbc87c73-8fcb-4502-86dd-a3198dac384f"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChooseQuickInventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""373be391-3875-442a-a339-7e2687c7dba2"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChooseQuickInventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f6579263-732c-42c9-afbf-db4d0642fc6b"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChooseQuickInventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""967cf6b1-6e01-467d-8e73-198b39395744"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenShieldQuickInventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""93e826d6-743f-4ab6-a34e-c93c7ac0f3c9"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenShieldQuickInventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""775c9471-0af6-437d-a9d1-6ac1f303c798"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenBowQuickInventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dc57bcd6-189c-4b55-a293-6b09da7a6392"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenBowQuickInventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b08d8984-a686-4da6-b8bb-e23391e0c7df"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenArrowQuickInventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""85093224-0fc2-481b-af68-4686c21319fa"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenArrowQuickInventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Land
        m_Land = asset.FindActionMap("Land", throwIfNotFound: true);
        m_Land_Move = m_Land.FindAction("Move", throwIfNotFound: true);
        m_Land_MoveCamera = m_Land.FindAction("MoveCamera", throwIfNotFound: true);
        m_Land_Jump = m_Land.FindAction("Jump", throwIfNotFound: true);
        // Interaction
        m_Interaction = asset.FindActionMap("Interaction", throwIfNotFound: true);
        m_Interaction_SelectObj = m_Interaction.FindAction("SelectObj", throwIfNotFound: true);
        m_Interaction_OpenWeaponQuickInventory = m_Interaction.FindAction("OpenWeaponQuickInventory", throwIfNotFound: true);
        m_Interaction_ChooseQuickInventory = m_Interaction.FindAction("ChooseQuickInventory", throwIfNotFound: true);
        m_Interaction_OpenShieldQuickInventory = m_Interaction.FindAction("OpenShieldQuickInventory", throwIfNotFound: true);
        m_Interaction_OpenBowQuickInventory = m_Interaction.FindAction("OpenBowQuickInventory", throwIfNotFound: true);
        m_Interaction_OpenArrowQuickInventory = m_Interaction.FindAction("OpenArrowQuickInventory", throwIfNotFound: true);
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

    // Land
    private readonly InputActionMap m_Land;
    private ILandActions m_LandActionsCallbackInterface;
    private readonly InputAction m_Land_Move;
    private readonly InputAction m_Land_MoveCamera;
    private readonly InputAction m_Land_Jump;
    public struct LandActions
    {
        private @PlayerControls m_Wrapper;
        public LandActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Land_Move;
        public InputAction @MoveCamera => m_Wrapper.m_Land_MoveCamera;
        public InputAction @Jump => m_Wrapper.m_Land_Jump;
        public InputActionMap Get() { return m_Wrapper.m_Land; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(LandActions set) { return set.Get(); }
        public void SetCallbacks(ILandActions instance)
        {
            if (m_Wrapper.m_LandActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_LandActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_LandActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_LandActionsCallbackInterface.OnMove;
                @MoveCamera.started -= m_Wrapper.m_LandActionsCallbackInterface.OnMoveCamera;
                @MoveCamera.performed -= m_Wrapper.m_LandActionsCallbackInterface.OnMoveCamera;
                @MoveCamera.canceled -= m_Wrapper.m_LandActionsCallbackInterface.OnMoveCamera;
                @Jump.started -= m_Wrapper.m_LandActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_LandActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_LandActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_LandActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @MoveCamera.started += instance.OnMoveCamera;
                @MoveCamera.performed += instance.OnMoveCamera;
                @MoveCamera.canceled += instance.OnMoveCamera;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
            }
        }
    }
    public LandActions @Land => new LandActions(this);

    // Interaction
    private readonly InputActionMap m_Interaction;
    private IInteractionActions m_InteractionActionsCallbackInterface;
    private readonly InputAction m_Interaction_SelectObj;
    private readonly InputAction m_Interaction_OpenWeaponQuickInventory;
    private readonly InputAction m_Interaction_ChooseQuickInventory;
    private readonly InputAction m_Interaction_OpenShieldQuickInventory;
    private readonly InputAction m_Interaction_OpenBowQuickInventory;
    private readonly InputAction m_Interaction_OpenArrowQuickInventory;
    public struct InteractionActions
    {
        private @PlayerControls m_Wrapper;
        public InteractionActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @SelectObj => m_Wrapper.m_Interaction_SelectObj;
        public InputAction @OpenWeaponQuickInventory => m_Wrapper.m_Interaction_OpenWeaponQuickInventory;
        public InputAction @ChooseQuickInventory => m_Wrapper.m_Interaction_ChooseQuickInventory;
        public InputAction @OpenShieldQuickInventory => m_Wrapper.m_Interaction_OpenShieldQuickInventory;
        public InputAction @OpenBowQuickInventory => m_Wrapper.m_Interaction_OpenBowQuickInventory;
        public InputAction @OpenArrowQuickInventory => m_Wrapper.m_Interaction_OpenArrowQuickInventory;
        public InputActionMap Get() { return m_Wrapper.m_Interaction; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InteractionActions set) { return set.Get(); }
        public void SetCallbacks(IInteractionActions instance)
        {
            if (m_Wrapper.m_InteractionActionsCallbackInterface != null)
            {
                @SelectObj.started -= m_Wrapper.m_InteractionActionsCallbackInterface.OnSelectObj;
                @SelectObj.performed -= m_Wrapper.m_InteractionActionsCallbackInterface.OnSelectObj;
                @SelectObj.canceled -= m_Wrapper.m_InteractionActionsCallbackInterface.OnSelectObj;
                @OpenWeaponQuickInventory.started -= m_Wrapper.m_InteractionActionsCallbackInterface.OnOpenWeaponQuickInventory;
                @OpenWeaponQuickInventory.performed -= m_Wrapper.m_InteractionActionsCallbackInterface.OnOpenWeaponQuickInventory;
                @OpenWeaponQuickInventory.canceled -= m_Wrapper.m_InteractionActionsCallbackInterface.OnOpenWeaponQuickInventory;
                @ChooseQuickInventory.started -= m_Wrapper.m_InteractionActionsCallbackInterface.OnChooseQuickInventory;
                @ChooseQuickInventory.performed -= m_Wrapper.m_InteractionActionsCallbackInterface.OnChooseQuickInventory;
                @ChooseQuickInventory.canceled -= m_Wrapper.m_InteractionActionsCallbackInterface.OnChooseQuickInventory;
                @OpenShieldQuickInventory.started -= m_Wrapper.m_InteractionActionsCallbackInterface.OnOpenShieldQuickInventory;
                @OpenShieldQuickInventory.performed -= m_Wrapper.m_InteractionActionsCallbackInterface.OnOpenShieldQuickInventory;
                @OpenShieldQuickInventory.canceled -= m_Wrapper.m_InteractionActionsCallbackInterface.OnOpenShieldQuickInventory;
                @OpenBowQuickInventory.started -= m_Wrapper.m_InteractionActionsCallbackInterface.OnOpenBowQuickInventory;
                @OpenBowQuickInventory.performed -= m_Wrapper.m_InteractionActionsCallbackInterface.OnOpenBowQuickInventory;
                @OpenBowQuickInventory.canceled -= m_Wrapper.m_InteractionActionsCallbackInterface.OnOpenBowQuickInventory;
                @OpenArrowQuickInventory.started -= m_Wrapper.m_InteractionActionsCallbackInterface.OnOpenArrowQuickInventory;
                @OpenArrowQuickInventory.performed -= m_Wrapper.m_InteractionActionsCallbackInterface.OnOpenArrowQuickInventory;
                @OpenArrowQuickInventory.canceled -= m_Wrapper.m_InteractionActionsCallbackInterface.OnOpenArrowQuickInventory;
            }
            m_Wrapper.m_InteractionActionsCallbackInterface = instance;
            if (instance != null)
            {
                @SelectObj.started += instance.OnSelectObj;
                @SelectObj.performed += instance.OnSelectObj;
                @SelectObj.canceled += instance.OnSelectObj;
                @OpenWeaponQuickInventory.started += instance.OnOpenWeaponQuickInventory;
                @OpenWeaponQuickInventory.performed += instance.OnOpenWeaponQuickInventory;
                @OpenWeaponQuickInventory.canceled += instance.OnOpenWeaponQuickInventory;
                @ChooseQuickInventory.started += instance.OnChooseQuickInventory;
                @ChooseQuickInventory.performed += instance.OnChooseQuickInventory;
                @ChooseQuickInventory.canceled += instance.OnChooseQuickInventory;
                @OpenShieldQuickInventory.started += instance.OnOpenShieldQuickInventory;
                @OpenShieldQuickInventory.performed += instance.OnOpenShieldQuickInventory;
                @OpenShieldQuickInventory.canceled += instance.OnOpenShieldQuickInventory;
                @OpenBowQuickInventory.started += instance.OnOpenBowQuickInventory;
                @OpenBowQuickInventory.performed += instance.OnOpenBowQuickInventory;
                @OpenBowQuickInventory.canceled += instance.OnOpenBowQuickInventory;
                @OpenArrowQuickInventory.started += instance.OnOpenArrowQuickInventory;
                @OpenArrowQuickInventory.performed += instance.OnOpenArrowQuickInventory;
                @OpenArrowQuickInventory.canceled += instance.OnOpenArrowQuickInventory;
            }
        }
    }
    public InteractionActions @Interaction => new InteractionActions(this);
    public interface ILandActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnMoveCamera(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
    public interface IInteractionActions
    {
        void OnSelectObj(InputAction.CallbackContext context);
        void OnOpenWeaponQuickInventory(InputAction.CallbackContext context);
        void OnChooseQuickInventory(InputAction.CallbackContext context);
        void OnOpenShieldQuickInventory(InputAction.CallbackContext context);
        void OnOpenBowQuickInventory(InputAction.CallbackContext context);
        void OnOpenArrowQuickInventory(InputAction.CallbackContext context);
    }
}
