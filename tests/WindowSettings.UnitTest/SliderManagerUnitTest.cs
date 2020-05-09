using System.Windows;
using WindowSettings.Business.Managers;
using Xunit;

namespace WindowSettings.UnitTest
{
    public class SliderManagerUnitTest
    {
        private readonly FrameworkElement SliderContainer;
        private Size arrangeBounds;
        Rect rectStart, rectEnd;

        [Fact]
        public void CanExecuteHorizontalOrientation()
        {
            RangeSliderManager.ManageHorizontalOrientation(SliderContainer, 1, 2, arrangeBounds, 1, 2, out rectStart, out rectEnd);
            if (rectStart != null && rectEnd != null)
                Assert.True(true);
            else Assert.True(false);
            
            
        }

        [Fact]
        public void CanExecuteVerticalOrientation()
        {
            RangeSliderManager.ManageVerticalOrientation(SliderContainer, 1, 2, arrangeBounds, 1, 2, out rectStart, out rectEnd);
            if (rectStart != null && rectEnd != null)
                Assert.True(true);
            else Assert.True(false);
        }
    }
}
