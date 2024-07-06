using UnityEngine;

namespace Player.Input
{
    public interface IInputHandler
    {
        public Vector2 GetMoveInput();

        public bool GetInteractInput();
    }
}