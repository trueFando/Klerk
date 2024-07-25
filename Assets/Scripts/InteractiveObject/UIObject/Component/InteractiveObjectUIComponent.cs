using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace InteractiveObject.UIObject.Component
{
    public class InteractiveObjectUIComponent : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private TextMeshProUGUI _taskNameUI;
        [SerializeField] private TextMeshProUGUI _taskTimerUI;
        [SerializeField] private TextMeshProUGUI _taskPenaltyUI;
        [SerializeField] private Image _taskImageUI;
        [SerializeField] private Image _taskProgressBarUI;

        private string _taskName;
        private float _taskFullTime;
        private float _taskPenalty;
        private Sprite _taskImage;

        public void Setup(string name, float fullTime, float penalty, Sprite image)
        {
            _taskName = name;
            _taskNameUI.text = _taskName;
            
            _taskFullTime = fullTime;
            _taskTimerUI.text = FormatTimeToMinutesAndSeconds(_taskFullTime);
            
            _taskPenalty = penalty;
            _taskPenaltyUI.text = $"-{_taskPenalty}";
            
            _taskImage = image;
            _taskImageUI.sprite = _taskImage;
        }

        /**
         * Get time format MM:SS
         */
        private string FormatTimeToMinutesAndSeconds(float seconds)
        {
            // todo implement
            return string.Empty;
        }
    }
}