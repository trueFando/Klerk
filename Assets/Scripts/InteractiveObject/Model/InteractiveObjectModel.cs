using System;
using Task.Struct;
using UnityEngine;

namespace InteractiveObject.Model
{
    [Serializable]
    public class InteractiveObjectModel
    {
        private const float MaxProgressValue = 100f;
        private const float DeltaProgressValue = 5f;
        private const float MaxFullTime = 120f;
        
        public float ProgressDelta => DeltaProgressValue;
        public float ProgressMax => MaxProgressValue;
        
        public event Action<float> OnProgressUpdate;
        public event Action<TaskData> OnTaskUpdate;
        public event Action<float> OnRemainingTimeUpdate;
        
        private float _progressValue;
        
        public float Progress
        {
            get => _progressValue;
            set
            {
                _progressValue = Mathf.Clamp(value, 0f, MaxProgressValue);
                
                OnProgressUpdate?.Invoke(_progressValue);
            }
        }

        private TaskData _taskData;

        public TaskData TaskData
        {
            get => _taskData;
            set
            {
                var name = value.Name != string.Empty ? value.Name : "Interesting task";
                var fullTime = Mathf.Clamp(value.FullTime, 0f, MaxFullTime);
                var reward = Mathf.Max(value.Reward, 0);
                var penalty = Mathf.Max(value.Penalty, 0);
                
                _taskData = new TaskData(name, fullTime, reward, penalty);
                
                OnTaskUpdate?.Invoke(_taskData);
            }
        }

        private float _remainingTime;

        public float RemainingTime
        {
            get => _remainingTime;
            set
            {
                _remainingTime = Mathf.Clamp(value, 0f, _taskData.FullTime);
                
                OnRemainingTimeUpdate?.Invoke(_remainingTime);
            }
        }
    }
}