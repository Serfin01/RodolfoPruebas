// GENERATED AUTOMATICALLY FROM 'Assets/TextMesh Pro/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""CharacterControls"",
            ""id"": ""a8b84982-0a82-477e-a682-249919a2d77e"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f5161bf5-76f0-4119-a5ba-f8000da38a14"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""GodMode"",
                    ""type"": ""Button"",
                    ""id"": ""3384b1e5-b20b-429a-b185-28fc72062396"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""30201790-22c8-47cb-b73b-0c329a84bee3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Ability1"",
                    ""type"": ""Button"",
                    ""id"": ""44a54c89-9aa9-478f-b6f1-c3fc8df1cc96"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Ability2"",
                    ""type"": ""Button"",
                    ""id"": ""190611df-f564-47d1-87cd-80de72b206e5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Ability3"",
                    ""type"": ""Button"",
                    ""id"": ""f82633e3-7e82-44aa-959c-da6a3c31ce16"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Ability4"",
                    ""type"": ""Button"",
                    ""id"": ""712b784c-d74f-4ba3-b69f-55e89f7278a1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Invisibility"",
                    ""type"": ""Button"",
                    ""id"": ""b2941063-7efe-47f4-a28a-d9cbea60c343"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""GetAbility"",
                    ""type"": ""Button"",
                    ""id"": ""bfd9924f-b40e-4712-ace9-fcd014072727"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""b2a6fe37-7fe9-4bae-b7ed-fecb55d99ac1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""5c487c1c-1b55-482b-8b75-6dee60482599"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""5af3bf9f-edc3-4b9f-ac9a-eadd9194902f"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""62f1dbcc-a435-431a-88aa-a42da6035cd1"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""dbc3c255-e7ed-4442-86df-04618f20b598"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""53c46d0f-468b-4760-a787-681798411cf6"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b6107f6c-72b3-4b50-b401-e2e7851a8118"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""024bf975-0e39-459c-a93e-695e3c47714d"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": ""GamePad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8709621a-a1ab-4547-8382-3415e141b469"",
                    ""path"": ""<Keyboard>/f10"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard"",
                    ""action"": ""GodMode"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f0f71ff8-547f-4d0c-9b8d-59ce05e22dbf"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""da576944-d836-4eb5-a475-1246d8f09462"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f2ee67ae-36bf-4765-89f2-45cf27bc748e"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard"",
                    ""action"": ""Ability1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cf6694af-24d1-4946-ba5e-1ac30c979653"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Ability1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6f805655-2356-4b53-a92d-adc9fa74bc74"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard"",
                    ""action"": ""Ability4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bff9a9b2-98f6-40fc-ada0-fe83ddd53fbc"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Ability4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d7551f35-208d-44c4-98c2-2df42093a96d"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard"",
                    ""action"": ""Ability3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1db96f88-bdeb-46b7-8855-739e6f7fb9f4"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Ability3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c3799157-3e76-4c7c-977e-8028992b0d0f"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard"",
                    ""action"": ""Ability2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7a0069e8-a89c-41e2-b417-8483f3629f32"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Ability2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""575afa48-9565-44e2-a9d1-dcd6392224dc"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard"",
                    ""action"": ""Invisibility"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""49e298a0-53b4-4072-8a3d-4487ee5dc515"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Invisibility"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7cce7823-8c33-4ed8-9455-64fb0bd325ae"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard"",
                    ""action"": ""GetAbility"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7a704376-e646-4092-b674-19a02985eb4d"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""GetAbility"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d8125d01-3e97-414d-9078-a390e2cec096"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6824b09c-260a-4d08-a175-95752183634a"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""14a83d3c-296f-4364-898a-affa928eb5a0"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press,Hold(duration=0.01)"",
                    ""processors"": """",
                    ""groups"": ""keyboard"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2fd11dfe-5149-4127-9de1-d8c9d41cd2c8"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""keyboard"",
            ""bindingGroup"": ""keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""GamePad"",
            ""bindingGroup"": ""GamePad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // CharacterControls
        m_CharacterControls = asset.FindActionMap("CharacterControls", throwIfNotFound: true);
        m_CharacterControls_Movement = m_CharacterControls.FindAction("Movement", throwIfNotFound: true);
        m_CharacterControls_GodMode = m_CharacterControls.FindAction("GodMode", throwIfNotFound: true);
        m_CharacterControls_Dash = m_CharacterControls.FindAction("Dash", throwIfNotFound: true);
        m_CharacterControls_Ability1 = m_CharacterControls.FindAction("Ability1", throwIfNotFound: true);
        m_CharacterControls_Ability2 = m_CharacterControls.FindAction("Ability2", throwIfNotFound: true);
        m_CharacterControls_Ability3 = m_CharacterControls.FindAction("Ability3", throwIfNotFound: true);
        m_CharacterControls_Ability4 = m_CharacterControls.FindAction("Ability4", throwIfNotFound: true);
        m_CharacterControls_Invisibility = m_CharacterControls.FindAction("Invisibility", throwIfNotFound: true);
        m_CharacterControls_GetAbility = m_CharacterControls.FindAction("GetAbility", throwIfNotFound: true);
        m_CharacterControls_Pause = m_CharacterControls.FindAction("Pause", throwIfNotFound: true);
        m_CharacterControls_Shoot = m_CharacterControls.FindAction("Shoot", throwIfNotFound: true);
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

    // CharacterControls
    private readonly InputActionMap m_CharacterControls;
    private ICharacterControlsActions m_CharacterControlsActionsCallbackInterface;
    private readonly InputAction m_CharacterControls_Movement;
    private readonly InputAction m_CharacterControls_GodMode;
    private readonly InputAction m_CharacterControls_Dash;
    private readonly InputAction m_CharacterControls_Ability1;
    private readonly InputAction m_CharacterControls_Ability2;
    private readonly InputAction m_CharacterControls_Ability3;
    private readonly InputAction m_CharacterControls_Ability4;
    private readonly InputAction m_CharacterControls_Invisibility;
    private readonly InputAction m_CharacterControls_GetAbility;
    private readonly InputAction m_CharacterControls_Pause;
    private readonly InputAction m_CharacterControls_Shoot;
    public struct CharacterControlsActions
    {
        private @PlayerInput m_Wrapper;
        public CharacterControlsActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_CharacterControls_Movement;
        public InputAction @GodMode => m_Wrapper.m_CharacterControls_GodMode;
        public InputAction @Dash => m_Wrapper.m_CharacterControls_Dash;
        public InputAction @Ability1 => m_Wrapper.m_CharacterControls_Ability1;
        public InputAction @Ability2 => m_Wrapper.m_CharacterControls_Ability2;
        public InputAction @Ability3 => m_Wrapper.m_CharacterControls_Ability3;
        public InputAction @Ability4 => m_Wrapper.m_CharacterControls_Ability4;
        public InputAction @Invisibility => m_Wrapper.m_CharacterControls_Invisibility;
        public InputAction @GetAbility => m_Wrapper.m_CharacterControls_GetAbility;
        public InputAction @Pause => m_Wrapper.m_CharacterControls_Pause;
        public InputAction @Shoot => m_Wrapper.m_CharacterControls_Shoot;
        public InputActionMap Get() { return m_Wrapper.m_CharacterControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharacterControlsActions set) { return set.Get(); }
        public void SetCallbacks(ICharacterControlsActions instance)
        {
            if (m_Wrapper.m_CharacterControlsActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnMovement;
                @GodMode.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnGodMode;
                @GodMode.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnGodMode;
                @GodMode.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnGodMode;
                @Dash.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnDash;
                @Ability1.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnAbility1;
                @Ability1.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnAbility1;
                @Ability1.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnAbility1;
                @Ability2.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnAbility2;
                @Ability2.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnAbility2;
                @Ability2.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnAbility2;
                @Ability3.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnAbility3;
                @Ability3.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnAbility3;
                @Ability3.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnAbility3;
                @Ability4.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnAbility4;
                @Ability4.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnAbility4;
                @Ability4.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnAbility4;
                @Invisibility.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnInvisibility;
                @Invisibility.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnInvisibility;
                @Invisibility.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnInvisibility;
                @GetAbility.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnGetAbility;
                @GetAbility.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnGetAbility;
                @GetAbility.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnGetAbility;
                @Pause.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnPause;
                @Shoot.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnShoot;
            }
            m_Wrapper.m_CharacterControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @GodMode.started += instance.OnGodMode;
                @GodMode.performed += instance.OnGodMode;
                @GodMode.canceled += instance.OnGodMode;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @Ability1.started += instance.OnAbility1;
                @Ability1.performed += instance.OnAbility1;
                @Ability1.canceled += instance.OnAbility1;
                @Ability2.started += instance.OnAbility2;
                @Ability2.performed += instance.OnAbility2;
                @Ability2.canceled += instance.OnAbility2;
                @Ability3.started += instance.OnAbility3;
                @Ability3.performed += instance.OnAbility3;
                @Ability3.canceled += instance.OnAbility3;
                @Ability4.started += instance.OnAbility4;
                @Ability4.performed += instance.OnAbility4;
                @Ability4.canceled += instance.OnAbility4;
                @Invisibility.started += instance.OnInvisibility;
                @Invisibility.performed += instance.OnInvisibility;
                @Invisibility.canceled += instance.OnInvisibility;
                @GetAbility.started += instance.OnGetAbility;
                @GetAbility.performed += instance.OnGetAbility;
                @GetAbility.canceled += instance.OnGetAbility;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
            }
        }
    }
    public CharacterControlsActions @CharacterControls => new CharacterControlsActions(this);
    private int m_keyboardSchemeIndex = -1;
    public InputControlScheme keyboardScheme
    {
        get
        {
            if (m_keyboardSchemeIndex == -1) m_keyboardSchemeIndex = asset.FindControlSchemeIndex("keyboard");
            return asset.controlSchemes[m_keyboardSchemeIndex];
        }
    }
    private int m_GamePadSchemeIndex = -1;
    public InputControlScheme GamePadScheme
    {
        get
        {
            if (m_GamePadSchemeIndex == -1) m_GamePadSchemeIndex = asset.FindControlSchemeIndex("GamePad");
            return asset.controlSchemes[m_GamePadSchemeIndex];
        }
    }
    public interface ICharacterControlsActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnGodMode(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnAbility1(InputAction.CallbackContext context);
        void OnAbility2(InputAction.CallbackContext context);
        void OnAbility3(InputAction.CallbackContext context);
        void OnAbility4(InputAction.CallbackContext context);
        void OnInvisibility(InputAction.CallbackContext context);
        void OnGetAbility(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
    }
}
