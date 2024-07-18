using InteractiveObject.Handler.Abstract;
using Player.Input;
using UnityEngine;
using VContainer;

namespace InteractiveObject.Handler
{
    public class StayInteractingHandler : AInteractingHandler
    {
        [Inject]
        public StayInteractingHandler(IInputHandler inputHandler) : base(inputHandler)
        {
        }
        
        public override bool IsValid()
        {
            return true;
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