using InteractiveObject.Handler.Abstract;
using Player.Input;
using UnityEngine;
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

        public override float CalculateProgress(float oldValue, float deltaValue)
        {
            if (_isPointerUp)
            {
                if (_inputHandler.GetInteractInput())
                {
                    _isPointerUp = false;
                    return IncreaseProgress(oldValue, deltaValue);
                }
            }
            else
            {
                if (!_inputHandler.GetInteractInput())
                {
                    _isPointerUp = true;
                }
            }

            return DecreaseProgress(oldValue, deltaValue);
        }

        public override float IncreaseProgress(float oldValue, float deltaValue)
        {
            return oldValue + deltaValue;
        }

        public override float DecreaseProgress(float oldValue, float deltaValue)
        {
            return oldValue - deltaValue * Time.deltaTime;
        }
    }
}