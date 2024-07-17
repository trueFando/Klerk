using Common.UI;
using UnityEngine;
using VContainer;

namespace Player.Input
{
    public class InputHandlerMobile : IInputHandler
    {
        private readonly FloatingJoystick _joystick;
        private readonly CustomButton _interactButton;
        
        [Inject]
        public InputHandlerMobile(CustomButton interactButton, FloatingJoystick joystick)
        {
            _interactButton = interactButton;
            _joystick = joystick;
        }

        public Vector2 GetMoveInput()
        {
            var x = _joystick.Horizontal;
            var y = _joystick.Vertical;

            return new Vector2(x, y).normalized;
        }

        public bool GetInteractInput()
        {
            return _interactButton.IsPressed;
        }
    }
}