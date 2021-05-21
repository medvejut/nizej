// GENERATED AUTOMATICALLY FROM 'Assets/Settings/InputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Settings
{
    public class @InputActions : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @InputActions()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""33836a7e-7869-485c-91e3-c186d20600dd"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""30db0eda-c693-4181-9169-cb65a1b9e5b4"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""e7013de1-573a-4eda-bf29-f8999700aa60"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""939f8a24-4b7e-4992-a358-7295cc2ce247"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""341e11db-ad90-45fc-99a1-d84c8ea111d4"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""06359d61-c57d-4ccd-b451-13d44b247145"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""AD"",
                    ""id"": ""0a36ff78-8241-4d52-ac3d-7dae288e9b69"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""2639e9c8-58c1-4b02-9fee-0db104b5b153"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""756d57b2-2477-4872-a65a-bf18a90b9da8"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""4aa8475d-0e5a-4fb8-8367-594c8ee3ef90"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""7bb073d6-b20f-46ce-937c-03dd562b26e8"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""cad947c2-bd46-471c-a689-0b284a8ab678"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""GameOver"",
            ""id"": ""b347f26f-a1a4-43b0-9a25-42e71356beaa"",
            ""actions"": [
                {
                    ""name"": ""Restart"",
                    ""type"": ""Button"",
                    ""id"": ""35f7a236-3cda-4e81-a01d-ceaa6fe95d65"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ebea69a9-a098-4df3-bb77-c9ddcf46cea1"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Opening"",
            ""id"": ""5a02ccd7-a7aa-4649-a988-f3da5b6c96be"",
            ""actions"": [
                {
                    ""name"": ""Play"",
                    ""type"": ""Button"",
                    ""id"": ""4fd3d487-b6ea-4506-aa70-983b16e30d89"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f57afc23-bf07-44b3-aee6-6a3f285bafd4"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Play"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Gameplay
            m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
            m_Gameplay_Movement = m_Gameplay.FindAction("Movement", throwIfNotFound: true);
            m_Gameplay_Jump = m_Gameplay.FindAction("Jump", throwIfNotFound: true);
            // GameOver
            m_GameOver = asset.FindActionMap("GameOver", throwIfNotFound: true);
            m_GameOver_Restart = m_GameOver.FindAction("Restart", throwIfNotFound: true);
            // Opening
            m_Opening = asset.FindActionMap("Opening", throwIfNotFound: true);
            m_Opening_Play = m_Opening.FindAction("Play", throwIfNotFound: true);
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

        // Gameplay
        private readonly InputActionMap m_Gameplay;
        private IGameplayActions m_GameplayActionsCallbackInterface;
        private readonly InputAction m_Gameplay_Movement;
        private readonly InputAction m_Gameplay_Jump;
        public struct GameplayActions
        {
            private @InputActions m_Wrapper;
            public GameplayActions(@InputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Movement => m_Wrapper.m_Gameplay_Movement;
            public InputAction @Jump => m_Wrapper.m_Gameplay_Jump;
            public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
            public void SetCallbacks(IGameplayActions instance)
            {
                if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
                {
                    @Movement.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                    @Movement.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                    @Movement.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                    @Jump.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                    @Jump.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                    @Jump.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                }
                m_Wrapper.m_GameplayActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Movement.started += instance.OnMovement;
                    @Movement.performed += instance.OnMovement;
                    @Movement.canceled += instance.OnMovement;
                    @Jump.started += instance.OnJump;
                    @Jump.performed += instance.OnJump;
                    @Jump.canceled += instance.OnJump;
                }
            }
        }
        public GameplayActions @Gameplay => new GameplayActions(this);

        // GameOver
        private readonly InputActionMap m_GameOver;
        private IGameOverActions m_GameOverActionsCallbackInterface;
        private readonly InputAction m_GameOver_Restart;
        public struct GameOverActions
        {
            private @InputActions m_Wrapper;
            public GameOverActions(@InputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Restart => m_Wrapper.m_GameOver_Restart;
            public InputActionMap Get() { return m_Wrapper.m_GameOver; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(GameOverActions set) { return set.Get(); }
            public void SetCallbacks(IGameOverActions instance)
            {
                if (m_Wrapper.m_GameOverActionsCallbackInterface != null)
                {
                    @Restart.started -= m_Wrapper.m_GameOverActionsCallbackInterface.OnRestart;
                    @Restart.performed -= m_Wrapper.m_GameOverActionsCallbackInterface.OnRestart;
                    @Restart.canceled -= m_Wrapper.m_GameOverActionsCallbackInterface.OnRestart;
                }
                m_Wrapper.m_GameOverActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Restart.started += instance.OnRestart;
                    @Restart.performed += instance.OnRestart;
                    @Restart.canceled += instance.OnRestart;
                }
            }
        }
        public GameOverActions @GameOver => new GameOverActions(this);

        // Opening
        private readonly InputActionMap m_Opening;
        private IOpeningActions m_OpeningActionsCallbackInterface;
        private readonly InputAction m_Opening_Play;
        public struct OpeningActions
        {
            private @InputActions m_Wrapper;
            public OpeningActions(@InputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Play => m_Wrapper.m_Opening_Play;
            public InputActionMap Get() { return m_Wrapper.m_Opening; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(OpeningActions set) { return set.Get(); }
            public void SetCallbacks(IOpeningActions instance)
            {
                if (m_Wrapper.m_OpeningActionsCallbackInterface != null)
                {
                    @Play.started -= m_Wrapper.m_OpeningActionsCallbackInterface.OnPlay;
                    @Play.performed -= m_Wrapper.m_OpeningActionsCallbackInterface.OnPlay;
                    @Play.canceled -= m_Wrapper.m_OpeningActionsCallbackInterface.OnPlay;
                }
                m_Wrapper.m_OpeningActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Play.started += instance.OnPlay;
                    @Play.performed += instance.OnPlay;
                    @Play.canceled += instance.OnPlay;
                }
            }
        }
        public OpeningActions @Opening => new OpeningActions(this);
        public interface IGameplayActions
        {
            void OnMovement(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
        }
        public interface IGameOverActions
        {
            void OnRestart(InputAction.CallbackContext context);
        }
        public interface IOpeningActions
        {
            void OnPlay(InputAction.CallbackContext context);
        }
    }
}
