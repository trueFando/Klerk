using Animation.Character.Component;
using UnityEngine;

namespace Movement
{
    public class MovementComponent : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed;
        
        private AnimationComponent _animationComponent;

        private void Awake()
        {
            _animationComponent = GetComponent<AnimationComponent>();
        }

        public void MoveDirection(Vector3 direction)
        {
            transform.position += direction * (_movementSpeed * Time.deltaTime);
            
            if (direction.magnitude == 0)
            {
                _animationComponent.Stop();
            }
            else
            {
                if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
                {
                    _animationComponent.GoHorizontal(direction.x);
                }
                else
                {
                    if (direction.y >= 0)
                    {
                        _animationComponent.GoUp();
                    }
                    else
                    {
                        _animationComponent.GoDown();
                    }
                }
            }
        }
    }
}
