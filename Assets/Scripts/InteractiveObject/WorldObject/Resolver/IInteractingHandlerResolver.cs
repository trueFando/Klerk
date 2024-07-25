using InteractiveObject.WorldObject.Enum;
using InteractiveObject.WorldObject.Handler.Abstract;

namespace InteractiveObject.WorldObject.Resolver
{
    public interface IInteractingHandlerResolver
    {
        AInteractingHandler ResolveHandler(InteractiveObjectType type);
    }
}