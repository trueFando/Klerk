using UnityEngine.EventSystems;

namespace Common.UI
{
    public class CustomButton : EventTrigger
    {
        public bool IsPressed { get; private set; }

        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);

            IsPressed = true;
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);

            IsPressed = false;
        }
    }
}