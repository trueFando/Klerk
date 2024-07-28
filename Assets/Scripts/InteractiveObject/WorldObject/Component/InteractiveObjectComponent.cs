using System;
using InteractiveObject.UIObject.Interface;
using InteractiveObject.WorldObject.Enum;
using InteractiveObject.WorldObject.Handler.Abstract;
using InteractiveObject.WorldObject.Resolver;
using UnityEngine;
using VContainer;

namespace InteractiveObject.WorldObject.Component
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
        
        // dependencies
        private AInteractingHandler _interactingHandler;
        
        // ui must be a child so no need to register as dependency 
        [SerializeField] private IInteractiveObjectUI _uiObject;

        private bool _isActive;

        private void Awake()
        {
            SetActive(true);
        }

        [Inject]
        public void Construct(IInteractingHandlerResolver handlerResolver)
        {
            _interactingHandler = handlerResolver.ResolveHandler(_type);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!_isActive) return;
            
            _isHandlingInteracting = true;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (!_isActive) return;
            
            _isHandlingInteracting = false;
        }

        private void Update()
        {
            if (!_isActive) return;
            
            CalculateProgressValue();
        }

        public void SetActive(bool active)
        {
            ResetAll();
            _isActive = active;
        }

        private void ResetAll()
        {
            _progressValue = 0f;
        }

        private void CalculateProgressValue()
        {
            _progressValue = _isHandlingInteracting
                ? _interactingHandler.CalculateProgress(_progressValue, _deltaProgressValue)
                : _interactingHandler.DecreaseProgress(_progressValue, _deltaProgressValue);

            _progressValue = Mathf.Clamp(_progressValue, 0f, 100f);
        }
    }
}