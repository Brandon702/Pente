// GENERATED AUTOMATICALLY FROM 'Assets/Input/InputSystem.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputSystem : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputSystem()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputSystem"",
    ""maps"": [
        {
            ""name"": ""Game"",
            ""id"": ""f25519ac-520e-4bd1-ab20-0470a7208f96"",
            ""actions"": [
                {
                    ""name"": ""LMB"",
                    ""type"": ""Button"",
                    ""id"": ""9931b12e-5ea1-4974-83f5-505a9eb09892"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""0ddd926e-1635-4175-925b-6e3f742d5e3f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a9aad18c-e101-4fc2-874d-9795dbce3afd"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LMB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dbe09ec5-040b-4723-9140-045966031bf9"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""93312185-5f4e-419a-92bf-a7bd16a2c35c"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Main"",
            ""id"": ""4c6d325e-6f4a-46ad-8e55-e560ae0c7d6c"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""91c036ff-82b0-4b89-acb2-eed8bf5c69da"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""15e45116-5126-45e1-8cfa-0b9e504ea401"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Game
        m_Game = asset.FindActionMap("Game", throwIfNotFound: true);
        m_Game_LMB = m_Game.FindAction("LMB", throwIfNotFound: true);
        m_Game_Pause = m_Game.FindAction("Pause", throwIfNotFound: true);
        // Main
        m_Main = asset.FindActionMap("Main", throwIfNotFound: true);
        m_Main_Newaction = m_Main.FindAction("New action", throwIfNotFound: true);
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

    // Game
    private readonly InputActionMap m_Game;
    private IGameActions m_GameActionsCallbackInterface;
    private readonly InputAction m_Game_LMB;
    private readonly InputAction m_Game_Pause;
    public struct GameActions
    {
        private @InputSystem m_Wrapper;
        public GameActions(@InputSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @LMB => m_Wrapper.m_Game_LMB;
        public InputAction @Pause => m_Wrapper.m_Game_Pause;
        public InputActionMap Get() { return m_Wrapper.m_Game; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameActions set) { return set.Get(); }
        public void SetCallbacks(IGameActions instance)
        {
            if (m_Wrapper.m_GameActionsCallbackInterface != null)
            {
                @LMB.started -= m_Wrapper.m_GameActionsCallbackInterface.OnLMB;
                @LMB.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnLMB;
                @LMB.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnLMB;
                @Pause.started -= m_Wrapper.m_GameActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_GameActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LMB.started += instance.OnLMB;
                @LMB.performed += instance.OnLMB;
                @LMB.canceled += instance.OnLMB;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public GameActions @Game => new GameActions(this);

    // Main
    private readonly InputActionMap m_Main;
    private IMainActions m_MainActionsCallbackInterface;
    private readonly InputAction m_Main_Newaction;
    public struct MainActions
    {
        private @InputSystem m_Wrapper;
        public MainActions(@InputSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_Main_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_Main; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainActions set) { return set.Get(); }
        public void SetCallbacks(IMainActions instance)
        {
            if (m_Wrapper.m_MainActionsCallbackInterface != null)
            {
                @Newaction.started -= m_Wrapper.m_MainActionsCallbackInterface.OnNewaction;
                @Newaction.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnNewaction;
                @Newaction.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnNewaction;
            }
            m_Wrapper.m_MainActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
            }
        }
    }
    public MainActions @Main => new MainActions(this);
    public interface IGameActions
    {
        void OnLMB(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
    public interface IMainActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
}
