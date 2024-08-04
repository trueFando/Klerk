using Animation.Character.Component;
using UnityEngine;

namespace Movement
{
    public class MovementComponent : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed;
        [SerializeField] private LayerMask _levelMask;
        [SerializeField] private CircleCollider2D _collider;
        
        private AnimationComponent _animationComponent;

        private void Awake()
        {
            _animationComponent = GetComponent<AnimationComponent>();
        }

        public void MoveDirection(Vector3 direction)
        {
            if (!CanMove(direction))
            {
                var newDirection = direction;
                newDirection.x = 0;
                
                if (CanMove(newDirection))
                {
                    direction = newDirection;
                }
                else
                {
                    newDirection = direction;
                    newDirection.y = 0;
                    
                    if (CanMove(newDirection))
                    {
                        direction = newDirection;
                    }
                    else
                    {
                        return;
                    }
                }
            }
            
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

        private bool CanMove(Vector2 direction)
        {
            var distance = _movementSpeed * Time.deltaTime;
            var radius = _collider.radius;
            
            var results = Physics2D.CircleCastAll(transform.position, radius, direction, distance, _levelMask);
            
            return results.Length == 0;
        }
    }
}
