using InteractiveObject.Handler.Abstract;
using InteractiveObject.WorldObject.Enum;

namespace InteractiveObject.Handler.Resolver
{
    public interface IInteractingHandlerResolver
    {
        AInteractingHandler ResolveHandler(InteractiveObjectType type);
    }
}