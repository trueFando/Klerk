using Common.UI;
using InteractiveObject.Handler;
using InteractiveObject.Handler.Resolver;
using Player.Input;
using Task.TaskCreator.TaskCreatorComponent;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace DependencyInjection
{
    public class GameLifetimeScope : LifetimeScope
    {
        [Header("Dependencies")]
        [SerializeField] private CustomButton _interactButton;
        [SerializeField] private FloatingJoystick _joystick;
        [Header("Other")]
        [SerializeField] private Canvas _controlsCanvas;

        protected override void Configure(IContainerBuilder builder)
        {
            switch (UnityEngine.Device.SystemInfo.deviceType)
            {
                case DeviceType.Handheld:
                    builder.Register<IInputHandler, InputHandlerMobile>(Lifetime.Singleton);
                    break;
                case DeviceType.Desktop:
                    builder.Register<IInputHandler, InputHandlerPC>(Lifetime.Singleton);
                    _controlsCanvas.gameObject.SetActive(false);
                    break;
                case DeviceType.Unknown:
                case DeviceType.Console:
                default:
                    Debug.LogError("Not supported device");
                    Application.Quit();
                    break;
            }

            builder.RegisterComponent(_interactButton);
            builder.RegisterComponent(_joystick);
            
            // Interacting objects
            
            builder.Register<StayInteractingHandler>(Lifetime.Transient);
            builder.Register<TapInteractingHandler>(Lifetime.Transient);
            builder.Register<HoldInteractingHandler>(Lifetime.Transient);
            
            builder.Register<IInteractingHandlerResolver, InteractingHandleResolver>(Lifetime.Transient);
        }
    }
}