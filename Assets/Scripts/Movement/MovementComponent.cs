using UnityEngine;

namespace Movement
{
    public class MovementComponent : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed;
         
        public void MoveDirection(Vector3 direction)
        {
            transform.position += direction * _movementSpeed * Time.deltaTime;
        }
    }
}
