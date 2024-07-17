using Common.UI;
using Player.Input;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using UnityEngine.Device;

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
                    UnityEngine.Application.Quit();
                    break;
            }

            builder.RegisterComponent(_interactButton);
            builder.RegisterComponent(_joystick);
        }
    }
}