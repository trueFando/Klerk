﻿using System;
using InteractiveObject.WorldObject.Enum;
using InteractiveObject.WorldObject.Handler;
using InteractiveObject.WorldObject.Handler.Abstract;
using VContainer;

namespace InteractiveObject.WorldObject.Resolver
{
    public class InteractingHandleResolver : IInteractingHandlerResolver
    {
        private readonly IObjectResolver _resolver;

        public InteractingHandleResolver(IObjectResolver resolver)
        {
            _resolver = resolver;
        }

        public AInteractingHandler ResolveHandler(InteractiveObjectType type)
        {
            return type switch
            {
                InteractiveObjectType.Stay => _resolver.Resolve<StayInteractingHandler>(),
                InteractiveObjectType.Tap => _resolver.Resolve<TapInteractingHandler>(),
                InteractiveObjectType.Hold => _resolver.Resolve<HoldInteractingHandler>(),
                _ => throw new ArgumentException("Unknown handler type", nameof(type))
            };
        }
    }
}