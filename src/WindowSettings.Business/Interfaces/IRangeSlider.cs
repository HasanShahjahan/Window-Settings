using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace WindowSettings.Business.Interfaces
{
    public interface IRangeSlider
    {
        void ManageVerticalOrientation(FrameworkElement SliderContainer, double Minimum, double Maximum, Size arrangeBounds, double start, double end, out Rect rectStart, out Rect rectEnd);
        void ManageHorizontalOrientation(FrameworkElement SliderContainer, double Minimum, double Maximum, Size arrangeBounds, double start, double end, out Rect rectStart, out Rect rectEnd);
    }
}
