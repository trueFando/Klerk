using Helper;
using InteractiveObject.Handler.Abstract;
using InteractiveObject.Handler.Resolver;
using InteractiveObject.Model;
using InteractiveObject.UIOverlayObject.Component;
using InteractiveObject.WorldObject.Enum;
using Task.Struct;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace InteractiveObject.WorldObject.Component
{
    [RequireComponent(typeof(Collider2D))]
    public class InteractiveObjectComponent : MonoBehaviour
    {
        /// <summary>
        /// Entity data.
        /// </summary>
        [SerializeField] private InteractiveObjectModel _model = new();

        /// <summary>
        /// Type of interactive object.
        /// </summary>
        [Header("Type")]
        [SerializeField] private InteractiveObjectType _type;

        /// <summary>
        /// Handler defines progress Increase/Decrease methods.
        /// Will be resolved by [injected] IObjectResolver's inheritor according to _type.
        /// </summary>
        private AInteractingHandler _interactingHandler;

        /// <summary>
        /// Is the component active (i.e., does it listen to world events)?
        /// </summary>
        private bool _isActive;
        
        /// <summary>
        /// Is someone interacting with the component right now?
        /// </summary>
        private bool _isHandlingInteracting;

        /// <summary>
        /// UI object used as parent for tasks.
        /// </summary>
        [SerializeField] private RectTransform _tasksParent;

        /// <summary>
        /// Prefab of UI overlay object.
        /// </summary>
        [SerializeField] private InteractiveObjectUIOverlayOverlayComponent uiOverlayOverlayPrefab;

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

        public void SetupForNewTask(TaskData taskData)
        {
            // create uioverlay object
            var uiOverlayObj = Instantiate(uiOverlayOverlayPrefab, _tasksParent);
            
            // subscribe it to model's events
            _model.OnTaskUpdate += uiOverlayObj.Setup;
            _model.OnProgressUpdate += uiOverlayObj.SetProgressbarValue;
            
            _model.TaskData = taskData;
            SetActive(true);
        }

        private void SetActive(bool active)
        {
            ResetAll();
            _isActive = active;
        }

        private void ResetAll()
        {
            _model.Progress = 0f;
        }

        private void CalculateProgressValue()
        {
            _model.Progress = _isHandlingInteracting
                ? _interactingHandler.CalculateProgress(_model.Progress, _model.ProgressDelta)
                : _interactingHandler.DecreaseProgress(_model.Progress, _model.ProgressDelta);

            CheckIfDone();
        }

        private void CheckIfDone()
        {
            if (Mathf.Abs(_model.ProgressDelta - _model.ProgressMax) < StaticValues.FloatComparisonMaxError)
            {
                SetActive(false);
                
                // events invoke
            }
        }
    }
}