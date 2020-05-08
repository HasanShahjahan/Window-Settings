using System.Windows;

namespace WindowSettings.Business.Managers
{
    public class RangeSliderManager
    {
        public static void ManageVerticalOrientation(FrameworkElement SliderContainer, double Minimum, double Maximum, Size arrangeBounds, double start, double end, out Rect rectStart, out Rect rectEnd)
        {
            var viewportSize = SliderContainer != null ? SliderContainer.ActualHeight : arrangeBounds.Height;
            var startPosition = (start - Minimum) / (Maximum - Minimum) * viewportSize;
            var endPosition = (end - Minimum) / (Maximum - Minimum) * viewportSize;
            rectStart = new Rect(0, 0, arrangeBounds.Width, startPosition);
            rectEnd = new Rect(0, endPosition, arrangeBounds.Width, viewportSize - endPosition);
        }

        public static void ManageHorizontalOrientation(FrameworkElement SliderContainer, double Minimum, double Maximum, Size arrangeBounds, double start, double end, out Rect rectStart, out Rect rectEnd)
        {
            var viewportSize = SliderContainer != null ? SliderContainer.ActualWidth : arrangeBounds.Width;
            var startPosition = (start - Minimum) / (Maximum - Minimum) * viewportSize;
            var endPosition = (end - Minimum) / (Maximum - Minimum) * viewportSize;
            rectStart = new Rect(0, 0, startPosition, arrangeBounds.Height);
            rectEnd = new Rect(endPosition, 0, viewportSize - endPosition, arrangeBounds.Height);
        }
    }
}

