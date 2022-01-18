// GENERATED AUTOMATICALLY FROM 'Assets/Settings/Control/SimpleMouseControl.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @SimpleMouseControl : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @SimpleMouseControl()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""SimpleMouseControl"",
    ""maps"": [
        {
            ""name"": ""Game"",
            ""id"": ""ac0968db-1222-41ab-9cc5-39379048000f"",
            ""actions"": [
                {
                    ""name"": ""Position"",
                    ""type"": ""Value"",
                    ""id"": ""ced8dd4e-7450-41b8-a9ab-a1837437439d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""40959f21-4476-45ae-bc9b-92042156bbca"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=0.1)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""04f7d4e4-dcee-4009-b6fa-8f402b2f2c7b"",
                    ""path"": ""<Pointer>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""New control scheme"",
                    ""action"": ""Position"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""16025248-c901-47c3-b5bd-d8952d869315"",
                    ""path"": ""<Pointer>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""New control scheme"",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""New control scheme"",
            ""bindingGroup"": ""New control scheme"",
            ""devices"": [
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Game
        m_Game = asset.FindActionMap("Game", throwIfNotFound: true);
        m_Game_Position = m_Game.FindAction("Position", throwIfNotFound: true);
        m_Game_Down = m_Game.FindAction("Down", throwIfNotFound: true);
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
    private readonly InputAction m_Game_Position;
    private readonly InputAction m_Game_Down;
    public struct GameActions
    {
        private @SimpleMouseControl m_Wrapper;
        public GameActions(@SimpleMouseControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @Position => m_Wrapper.m_Game_Position;
        public InputAction @Down => m_Wrapper.m_Game_Down;
        public InputActionMap Get() { return m_Wrapper.m_Game; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameActions set) { return set.Get(); }
        public void SetCallbacks(IGameActions instance)
        {
            if (m_Wrapper.m_GameActionsCallbackInterface != null)
            {
                @Position.started -= m_Wrapper.m_GameActionsCallbackInterface.OnPosition;
                @Position.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnPosition;
                @Position.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnPosition;
                @Down.started -= m_Wrapper.m_GameActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnDown;
            }
            m_Wrapper.m_GameActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Position.started += instance.OnPosition;
                @Position.performed += instance.OnPosition;
                @Position.canceled += instance.OnPosition;
                @Down.started += instance.OnDown;
                @Down.performed += instance.OnDown;
                @Down.canceled += instance.OnDown;
            }
        }
    }
    public GameActions @Game => new GameActions(this);
    private int m_NewcontrolschemeSchemeIndex = -1;
    public InputControlScheme NewcontrolschemeScheme
    {
        get
        {
            if (m_NewcontrolschemeSchemeIndex == -1) m_NewcontrolschemeSchemeIndex = asset.FindControlSchemeIndex("New control scheme");
            return asset.controlSchemes[m_NewcontrolschemeSchemeIndex];
        }
    }
    public interface IGameActions
    {
        void OnPosition(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
    }
}
