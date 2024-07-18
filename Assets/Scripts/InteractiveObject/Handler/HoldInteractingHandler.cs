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

        public override bool IsValid()
        {
            return _inputHandler.GetInteractInput();
        }

        public override float IncreaseProgress(float oldValue, float deltaValue)
        {
            if (!IsValid()) return oldValue;

            return oldValue + deltaValue * Time.deltaTime;
        }

        public override float DecreaseProgress(float oldValue, float deltaValue)
        {
            if (!IsValid()) return oldValue;

            return oldValue - deltaValue * Time.deltaTime;
        }
    }
}