using InteractiveObject.Handler.Abstract;
using Player.Input;
using UnityEngine;
using VContainer;

namespace InteractiveObject.Handler
{
    public class HoldInteractingHandler : AInteractingHandler
    {
        [Inject]
        public HoldInteractingHandler(IInputHandler inputHandler) : base(inputHandler)
        {
        }

        public override float CalculateProgress(float oldValue, float deltaValue)
        {
            return _inputHandler.GetInteractInput() 
                ? IncreaseProgress(oldValue, deltaValue)
                : DecreaseProgress(oldValue, deltaValue);
        }
        
        public override float IncreaseProgress(float oldValue, float deltaValue)
        {
            return oldValue + deltaValue * Time.deltaTime;
        }

        public override float DecreaseProgress(float oldValue, float deltaValue)
        {
            return oldValue - deltaValue * Time.deltaTime;
        }
    }
}