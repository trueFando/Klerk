using Task.Struct;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace InteractiveObject.UIOverlayObject.Component
{
    public class InteractiveObjectUIOverlayOverlayComponent : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private TextMeshProUGUI _taskNameUI;
        [SerializeField] private TextMeshProUGUI _taskTimerUI;
        [SerializeField] private TextMeshProUGUI _taskPenaltyUI;
        [SerializeField] private TextMeshProUGUI _taskRewardUI;
        [SerializeField] private Image _taskProgressBarUI;

        private TaskData _taskData;
        
        public void Setup(TaskData taskData)
        {
            _taskData = taskData;
            
            _taskNameUI.text = _taskData.Name;
            _taskTimerUI.text = FormatTimeToMinutesAndSeconds(_taskData.FullTime);
            _taskPenaltyUI.text = $"-{_taskData.Penalty}";
            _taskRewardUI.text = $"+{_taskData.Reward}";
        }

        /// <summary>
        ///  Get time as string.
        /// </summary>
        /// <param name="totalSeconds">Total count of seconds</param>
        /// <returns>Time in format MM:SS</returns>
        private string FormatTimeToMinutesAndSeconds(float totalSeconds)
        {
            var minutes = (int)(totalSeconds / 60);
            var seconds = (int)(totalSeconds % 60);

            return $"{minutes:D2}:{seconds:D2}";
        }

        public void SetProgressbarValue(float value)
        {
            _taskProgressBarUI.transform.localScale = new Vector3(value, 1f, 1f);
        }

        public void Animate(float currentValue, float maxValue)
        {
            Debug.LogWarning("Animating! NOT IMPLEMENTED");
        }

        public void ShowSuccess()
        {
            Debug.Log("Task is done!");
        }

        public void ShowFail()
        {
            Debug.Log("Task is failed...");
        }
    }
}