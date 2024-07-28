namespace InteractiveObject.UIObject.Interface
{
    public interface IInteractiveObjectUI
    {
        /**
         * Fill progress bar. 
         */
        void SetProgressbarValue(float currentValue, float maxValue);

        /**
         * Do some animations according to progress.
         */
        void Animate(float currentValue, float maxValue);

        /**
         * Call to show that task is done.
         */
        void ShowSuccess();

        /**
         * Call to show that task is failed.
         */
        void ShowFail();
    }
}