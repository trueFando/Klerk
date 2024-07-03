using UnityEngine;

namespace Player.Input
{
    public interface IInputComponent
    {
        public Vector2 GetMoveInput();

        public bool GetInteractInput();
    }
}