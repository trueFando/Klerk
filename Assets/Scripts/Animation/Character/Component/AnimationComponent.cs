using UnityEngine;

namespace Animation.Character.Component
{
    public class AnimationComponent : MonoBehaviour
    {
        private const string StopTrigger = "stop";
        private const string GoHorizontalTrigger = "walk_horizontal";
        private const string GoUpTrigger = "walk_up";
        private const string GoDownTrigger = "walk_down";

        [SerializeField] private Animator _animator;
        [SerializeField] private Transform _targetTransform;

        public void Stop()
        {
            _animator.SetTrigger(StopTrigger);
        }

        public void GoHorizontal(float xDirection)
        {
            _animator.SetTrigger(GoHorizontalTrigger);
            
            var initialScale = _targetTransform.localScale;
            
            _targetTransform.localScale = new Vector3(Mathf.Sign(xDirection) * Mathf.Abs(initialScale.x),
                initialScale.y, initialScale.z);
        }

        public void GoUp()
        {
            _animator.SetTrigger(GoUpTrigger);
        }

        public void GoDown()
        {
            _animator.SetTrigger(GoDownTrigger);
        }
    }
}