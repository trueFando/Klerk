using UnityEngine;
using UnityEngine.UI;

namespace Player.Input
{
    public class InputHandlerMobile : IInputHandler
    {
        private FloatingJoystick _joystick;
        private Button _interactButton;
        private bool _isButtonPressed;

        private void Awake()
        {
            _interactButton.onClick.AddListener(SetIsButtonPressed);
        }

        private void OnDestroy()
        {
            _interactButton.onClick.RemoveListener(SetIsButtonPressed);
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