using Player.Input;
using VContainer;

namespace InteractiveObject.WorldObject.Handler.Abstract
{
    public abstract class AInteractingHandler
    {
        protected readonly IInputHandler _inputHandler;

        [Inject]
        protected AInteractingHandler(IInputHandler inputHandler)
        {
            _inputHandler = inputHandler;
        }

        public abstract float CalculateProgress(float oldValue, float deltaValue);

        public abstract float IncreaseProgress(float oldValue, float deltaValue);

        public abstract float DecreaseProgress(float oldValue, float deltaValue);
    }
}