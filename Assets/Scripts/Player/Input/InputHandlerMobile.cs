using System;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Player.Input
{
    public class InputHandlerMobile : IInputHandler
    {
        private FloatingJoystick _joystick;
        private Button _interactButton;
        private bool _isButtonPressed;

        [Inject]
        public InputHandlerMobile(Button interactButton, FloatingJoystick joystick)
        {
            _interactButton = interactButton;
            _interactButton.onClick.AddListener(SetIsButtonPressed);

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
            return _isButtonPressed;
        }

        private void SetIsButtonPressed()
        {
            _isButtonPressed = !_isButtonPressed;
        }
    }
}