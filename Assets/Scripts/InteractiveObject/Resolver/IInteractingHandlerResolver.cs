using InteractiveObject.Enum;
using InteractiveObject.Handler.Abstract;

namespace InteractiveObject.Resolver
{
    public interface IInteractingHandlerResolver
    {
        AInteractingHandler ResolveHandler(InteractiveObjectType type);
    }
}