using InteractiveObject.Enum;
using InteractiveObject.Handler.Abstract;

namespace InteractiveObject.Handler.Resolver
{
    public interface IInteractingHandlerResolver
    {
        AInteractingHandler ResolveHandler(InteractiveObjectType type);
    }
}