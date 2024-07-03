using UnityEngine;
using UnityEngine.UI;

namespace Player.Input
{
    public class InputComponentMobile : MonoBehaviour, IInputComponent
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
            float x = _joystick.Horizontal;
            float y = _joystick.Vertical;

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