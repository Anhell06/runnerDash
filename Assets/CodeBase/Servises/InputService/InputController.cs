// GENERATED AUTOMATICALLY FROM 'Assets/CodeBase/Servises/InputService/InputController.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputController : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputController"",
    ""maps"": [
        {
            ""name"": ""ForMobile"",
            ""id"": ""6bb6738e-b908-4a5a-8717-620728a6c743"",
            ""actions"": [
                {
                    ""name"": ""StartContact"",
                    ""type"": ""PassThrough"",
                    ""id"": ""a3e4617e-ae30-4dd1-ab6a-ff1d150e37a7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""TouchPosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""56831534-e4bd-466b-8d64-03c4c82ebae4"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1e4657ae-a38f-4f00-bde6-e77646399886"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StartContact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""96d3e6bb-9a02-470a-8ae0-c970144e0a0f"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // ForMobile
        m_ForMobile = asset.FindActionMap("ForMobile", throwIfNotFound: true);
        m_ForMobile_StartContact = m_ForMobile.FindAction("StartContact", throwIfNotFound: true);
        m_ForMobile_TouchPosition = m_ForMobile.FindAction("TouchPosition", throwIfNotFound: true);
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

    // ForMobile
    private readonly InputActionMap m_ForMobile;
    private IForMobileActions m_ForMobileActionsCallbackInterface;
    private readonly InputAction m_ForMobile_StartContact;
    private readonly InputAction m_ForMobile_TouchPosition;
    public struct ForMobileActions
    {
        private @InputController m_Wrapper;
        public ForMobileActions(@InputController wrapper) { m_Wrapper = wrapper; }
        public InputAction @StartContact => m_Wrapper.m_ForMobile_StartContact;
        public InputAction @TouchPosition => m_Wrapper.m_ForMobile_TouchPosition;
        public InputActionMap Get() { return m_Wrapper.m_ForMobile; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ForMobileActions set) { return set.Get(); }
        public void SetCallbacks(IForMobileActions instance)
        {
            if (m_Wrapper.m_ForMobileActionsCallbackInterface != null)
            {
                @StartContact.started -= m_Wrapper.m_ForMobileActionsCallbackInterface.OnStartContact;
                @StartContact.performed -= m_Wrapper.m_ForMobileActionsCallbackInterface.OnStartContact;
                @StartContact.canceled -= m_Wrapper.m_ForMobileActionsCallbackInterface.OnStartContact;
                @TouchPosition.started -= m_Wrapper.m_ForMobileActionsCallbackInterface.OnTouchPosition;
                @TouchPosition.performed -= m_Wrapper.m_ForMobileActionsCallbackInterface.OnTouchPosition;
                @TouchPosition.canceled -= m_Wrapper.m_ForMobileActionsCallbackInterface.OnTouchPosition;
            }
            m_Wrapper.m_ForMobileActionsCallbackInterface = instance;
            if (instance != null)
            {
                @StartContact.started += instance.OnStartContact;
                @StartContact.performed += instance.OnStartContact;
                @StartContact.canceled += instance.OnStartContact;
                @TouchPosition.started += instance.OnTouchPosition;
                @TouchPosition.performed += instance.OnTouchPosition;
                @TouchPosition.canceled += instance.OnTouchPosition;
            }
        }
    }
    public ForMobileActions @ForMobile => new ForMobileActions(this);
    public interface IForMobileActions
    {
        void OnStartContact(InputAction.CallbackContext context);
        void OnTouchPosition(InputAction.CallbackContext context);
    }
}
