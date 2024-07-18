using InteractiveObject.Handler.Abstract;
using Player.Input;
using VContainer;

namespace InteractiveObject.Handler
{
    public class TapInteractingHandler : AInteractingHandler
    {
        private bool _isPointerUp = true;
     
        [Inject]
        public TapInteractingHandler(IInputHandler inputHandler) : base(inputHandler)
        {
        }
        
        public override bool IsValid()
        {
            if (_isPointerUp)
            {
                if (_inputHandler.GetInteractInput())
                {
                    _isPointerUp = false;
                    return _inputHandler.GetInteractInput();
                }
            }

            return false;
        }

        public override float IncreaseProgress(float oldValue, float deltaValue)
        {
            if (!IsValid()) return oldValue;
            
            return oldValue + deltaValue;
        }

        public override float DecreaseProgress(float oldValue, float deltaValue)
        {
            if (!IsValid()) return oldValue;
            
            return oldValue - deltaValue;
        }
    }
}