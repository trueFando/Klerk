using UnityEngine;

namespace Player.Input
{
    public class InputHandlerPC : IInputHandler
    {
        public Vector2 GetMoveInput()
        {
            var x = UnityEngine.Input.GetAxis("Horizontal");
            var y = UnityEngine.Input.GetAxis("Vertical");

            return new Vector2(x, y).normalized;
        }

        public bool GetInteractInput()
        {
            return UnityEngine.Input.GetKey(KeyCode.E);
        }
    }
}