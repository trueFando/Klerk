using System;
using Movement;
using UnityEngine;
using VContainer;

namespace Player.Input
{
    public class PlayerInputComponent : MonoBehaviour
    {
        private IInputHandler _inputHandler;
        private MovementComponent _movementComponent;

        private void Awake()
        {
            _movementComponent = GetComponent<MovementComponent>();
        }

        [Inject]
        private void Construct(IInputHandler inputHandler)
        {
            _inputHandler = inputHandler;
            Debug.Log(_inputHandler.GetType());
        }

        private void Update()
        {
            _movementComponent.MoveDirection(_inputHandler.GetMoveInput());
        }
    }
}