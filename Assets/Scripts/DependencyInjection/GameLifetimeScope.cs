using Player.Input;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
using VContainer.Unity;

namespace DependencyInjection
{
    public class GameLifetimeScope : LifetimeScope
    {
        [Header("Dependencies")]
        [SerializeField] private Button _interactButton;
        [SerializeField] private FloatingJoystick _joystick;
        [Header("Other")]
        [SerializeField] private Canvas _controlsCanvas;

        protected override void Configure(IContainerBuilder builder)
        {
            switch (SystemInfo.deviceType)
            {
                case DeviceType.Handheld:
                    builder.Register<IInputHandler, InputHandlerMobile>(Lifetime.Singleton);
                    break;
                case DeviceType.Desktop:
                    builder.Register<IInputHandler, InputHandlerPC>(Lifetime.Singleton);
                    _controlsCanvas.gameObject.SetActive(false);
                    break;
                default:
                    Debug.LogError("Not supported device");
                    Application.Quit();
                    break;
            }

            builder.RegisterComponent(_interactButton);
            builder.RegisterComponent(_joystick);
        }
    }
}