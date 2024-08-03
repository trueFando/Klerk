using InteractiveObject.UIObject.Interface;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace InteractiveObject.UIOverlayObject.Component
{
    public class InteractiveObjectUIOverlayComponent : MonoBehaviour, IInteractiveObjectUI
    {
        [Header("UI")]
        [SerializeField] private TextMeshProUGUI _taskNameUI;
        [SerializeField] private TextMeshProUGUI _taskTimerUI;
        [SerializeField] private TextMeshProUGUI _taskPenaltyUI;
        [SerializeField] private TextMeshProUGUI _taskRewardUI;
        [SerializeField] private Image _taskProgressBarUI;

        private float _fullTime;
        
        public void Setup(string name, float fullTime, float penalty)
        {
            _taskNameUI.text = name;
            _taskTimerUI.text = FormatTimeToMinutesAndSeconds(fullTime);
            _taskPenaltyUI.text = $"-{penalty}";
        }

        /// <summary>
        ///  Get time as string.
        /// </summary>
        /// <param name="seconds">Total count of seconds</param>
        /// <returns>Time in format MM:SS</returns>
        private string FormatTimeToMinutesAndSeconds(float seconds)
        {
            // todo implement
            return string.Empty;
        }

        public void SetProgressbarValue(float currentValue, float maxValue)
        {
            throw new System.NotImplementedException();
        }

        public void Animate(float currentValue, float maxValue)
        {
            throw new System.NotImplementedException();
        }

        public void ShowSuccess()
        {
            Debug.Log("Task is done!");
        }

        public void ShowFail()
        {
            throw new System.NotImplementedException();
        }
    }
}