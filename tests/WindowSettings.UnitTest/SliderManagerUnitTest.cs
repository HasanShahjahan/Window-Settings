using System.Windows;
using WindowSettings.Business.Managers;
using Xunit;

namespace WindowSettings.UnitTest
{
    public class SliderManagerUnitTest
    {
        Rect rectStart, rectEnd;
        public FrameworkElement SliderContainer { get; }
        public Size ArrangeBounds { get; }

        [Fact]
        public void CanExecuteHorizontalOrientation()
        {
            RangeSliderManager.ManageHorizontalOrientation(SliderContainer, 1, 2, ArrangeBounds, 1, 2, out rectStart, out rectEnd);
            if (rectStart != null && rectEnd != null)
                Assert.True(true);
            else Assert.True(false);
            
            
        }

        [Fact]
        public void CanExecuteVerticalOrientation()
        {
            RangeSliderManager.ManageVerticalOrientation(SliderContainer, 1, 2, ArrangeBounds, 1, 2, out rectStart, out rectEnd);
            if (rectStart != null && rectEnd != null)
                Assert.True(true);
            else Assert.True(false);
        }
    }
}
