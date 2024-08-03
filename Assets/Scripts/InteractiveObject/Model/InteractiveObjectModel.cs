using System;
using UnityEngine;

namespace InteractiveObject.Model
{
    [Serializable]
    public class InteractiveObjectModel
    {
        public event Action<float> OnProgressChange;

        private const float _maxProgressValue = 100f;
        private const float _deltaProgressValue = 5f;
        
        private float _progressValue;
        
        public float Progress
        {
            get => _progressValue;
            set
            {
                _progressValue = Mathf.Clamp(value, 0f, _maxProgressValue);
                
                OnProgressChange?.Invoke(_progressValue);
            }
        }

        public float ProgressDelta => _deltaProgressValue;

        public float ProgressMax => _maxProgressValue;
    }
}