using InteractiveObject.Enum;
using InteractiveObject.Handler.Abstract;
using InteractiveObject.Handler.Resolver;
using UnityEngine;
using VContainer;

namespace InteractiveObject.Component
{
    [RequireComponent(typeof(Collider2D))]
    public class InteractiveObjectComponent : MonoBehaviour
    {
        [Header("Type")] 
        [SerializeField] private InteractiveObjectType _type;
        
        private float _progressValue = 0f;
        [Header("Progress")] 
        [SerializeField] private float _deltaProgressValue;

        private bool _isHandlingInteracting;

        private AInteractingHandler _interactingHandler;

        [Inject]
        public void Construct(IInteractingHandlerResolver handlerResolver)
        {
            Debug.Log($"Construct called with type: {_type}");
            _interactingHandler = handlerResolver.ResolveHandler(_type);
            Debug.Log($"Handler resolved: {_interactingHandler?.GetType().Name}");
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            _isHandlingInteracting = true;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            _isHandlingInteracting = false;
        }

        private void Update()
        {
            CalculateProgressValue();
        }

        private void CalculateProgressValue()
        {
            _progressValue = _isHandlingInteracting
                ? _interactingHandler.IncreaseProgress(_progressValue, _deltaProgressValue)
                : _interactingHandler.DecreaseProgress(_progressValue, _deltaProgressValue);

            _progressValue = Mathf.Clamp(_progressValue, 0f, 100f);
        }
    }
}