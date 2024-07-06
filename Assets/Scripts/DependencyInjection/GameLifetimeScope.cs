using Player.Input;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace DependencyInjection
{
    public class GameLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            if (SystemInfo.deviceType == DeviceType.Handheld)
            {
                builder.Register<IInputHandler, InputHandlerMobile>(Lifetime.Singleton);
            }
            else
            {
                builder.Register<IInputHandler, InputHandlerPC>(Lifetime.Singleton);
            }
        }
    }
}

