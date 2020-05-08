using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using WindowSettings.Business.Managers;
using WindowSettings.Common.Enums;

namespace WindowSettings.App
{
    public class RangeSlider : Control
    {
        FrameworkElement SliderContainer;
        Thumb StartThumb, EndThumb;
        FrameworkElement StartArea;
        FrameworkElement EndArea;

        public static readonly DependencyProperty MaximumProperty = DependencyProperty.Register(DependencyPropertyType.MaximumProperty, typeof(double), typeof(RangeSlider),
            new FrameworkPropertyMetadata(2d, FrameworkPropertyMetadataOptions.AffectsMeasure));
        public static readonly DependencyProperty MinimumProperty = DependencyProperty.Register(DependencyPropertyType.MinimumProperty, typeof(double), typeof(RangeSlider),
            new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.AffectsMeasure));
        public static readonly DependencyProperty StartProperty = DependencyProperty.Register(DependencyPropertyType.StarProperty, typeof(double), typeof(RangeSlider),
            new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public static readonly DependencyProperty EndProperty = DependencyProperty.Register(DependencyPropertyType.EndProperty, typeof(double), typeof(RangeSlider),
            new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public static readonly DependencyProperty OrientationProperty = DependencyProperty.Register(DependencyPropertyType.Orientation, typeof(Orientation), typeof(RangeSlider),
            new FrameworkPropertyMetadata(Orientation.Horizontal, FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsMeasure));
        public static readonly DependencyProperty IsMoveToPointEnabledProperty = DependencyProperty.Register(DependencyPropertyType.IsMoveToPointEnabled, typeof(bool), typeof(RangeSlider), new FrameworkPropertyMetadata(true));
        public static readonly DependencyProperty StartThumbToolTipProperty = DependencyProperty.Register(DependencyPropertyType.StartThumbToolTip, typeof(object), typeof(RangeSlider));
        public static readonly DependencyProperty EndThumbToolTipProperty = DependencyProperty.Register(DependencyPropertyType.EndThumbToolTip, typeof(object), typeof(RangeSlider));
        public static readonly DependencyProperty StartThumbStyleProperty = DependencyProperty.Register(DependencyPropertyType.StartThumbStyle, typeof(Style), typeof(RangeSlider));
        public static readonly DependencyProperty EndThumbStyleProperty = DependencyProperty.Register(DependencyPropertyType.EndThumbStyle, typeof(Style), typeof(RangeSlider));
        public static readonly DependencyProperty IsReadOnlyProperty = DependencyProperty.Register(DependencyPropertyType.IsReadOnly, typeof(bool), typeof(RangeSlider));

        public RangeSlider()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RangeSlider), new FrameworkPropertyMetadata(typeof(RangeSlider)));
            EventManager.RegisterClassHandler(typeof(RangeSlider), Thumb.DragStartedEvent, new DragStartedEventHandler(OnDragStartedEvent));
            EventManager.RegisterClassHandler(typeof(RangeSlider), Thumb.DragDeltaEvent, new DragDeltaEventHandler(OnThumbDragDelta));
            EventManager.RegisterClassHandler(typeof(RangeSlider), Thumb.DragCompletedEvent, new DragCompletedEventHandler(OnDragCompletedEvent));
        }

        public Orientation Orientation
        {
            get => (Orientation)GetValue(OrientationProperty);
            set => SetValue(OrientationProperty, value);
        }

        public double Maximum
        {
            get => (double)GetValue(MaximumProperty);
            set => SetValue(MaximumProperty, value);
        }

        public double Minimum
        {
            get => (double)GetValue(MinimumProperty);
            set => SetValue(MinimumProperty, value);
        }

        public double Start
        {
            get => (double)GetValue(StartProperty);
            set => SetValue(StartProperty, value);
        }

        public double End
        {
            get => (double)GetValue(EndProperty);
            set => SetValue(EndProperty, value);
        }

        public bool IsMoveToPointEnabled
        {
            get => (bool)GetValue(IsMoveToPointEnabledProperty);
            set => SetValue(IsMoveToPointEnabledProperty, value);
        }

        public object StartThumbToolTip
        {
            get => GetValue(StartThumbToolTipProperty);
            set => SetValue(StartThumbToolTipProperty, value);
        }

        public object EndThumbToolTip
        {
            get => GetValue(EndThumbToolTipProperty);
            set => SetValue(EndThumbToolTipProperty, value);
        }

        public Style StartThumbStyle
        {
            get => (Style)GetValue(StartThumbStyleProperty);
            set => SetValue(StartThumbStyleProperty, value);
        }

        public Style EndThumbStyle
        {
            get => (Style)GetValue(EndThumbStyleProperty);
            set => SetValue(EndThumbStyleProperty, value);
        }

        public bool IsReadOnly
        {
            get => (bool)GetValue(IsReadOnlyProperty);
            set => SetValue(IsReadOnlyProperty, value);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            SliderContainer = GetTemplateChild(DependencyPropertyType.PART_SliderContainer) as FrameworkElement;
            if (SliderContainer != null)
            {
                SliderContainer.PreviewMouseDown += ViewBox_PreviewMouseDown;
            }

            StartArea = GetTemplateChild(DependencyPropertyType.PART_StartArea) as FrameworkElement;
            EndArea = GetTemplateChild(DependencyPropertyType.PART_EndArea) as FrameworkElement;
            StartThumb = GetTemplateChild(DependencyPropertyType.PART_StartThumb) as Thumb;
            EndThumb = GetTemplateChild(DependencyPropertyType.PART_EndThumb) as Thumb;
        }

        protected override Size ArrangeOverride(Size arrangeBounds)
        {
            var arrangeSize = base.ArrangeOverride(arrangeBounds);
            if (Maximum > Minimum && StartArea != null && EndArea != null)
            {
                var start = Math.Max(Minimum, Math.Min(Maximum, Start));
                var end = Math.Max(Minimum, Math.Min(Maximum, End));
                Rect rectStart, rectEnd;
                if (Orientation == Orientation.Horizontal) RangeSliderManager.ManageHorizontalOrientation(SliderContainer, Minimum, Maximum, arrangeBounds, start, end, out rectStart, out rectEnd);
                else RangeSliderManager.ManageVerticalOrientation(SliderContainer, Minimum, Maximum, arrangeBounds, start, end, out rectStart, out rectEnd);

                if (StartArea != null) StartArea.Arrange(rectStart);
                if (EndArea != null) EndArea.Arrange(rectEnd);
                if (StartThumb != null) StartThumb.Arrange(rectStart);
                if (EndThumb != null) EndThumb.Arrange(rectEnd);
            }
            if (arrangeSize.Width != 1.00) arrangeSize.Width *= Maximum;
            return arrangeSize;
        }

        private void ViewBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!IsReadOnly && IsMoveToPointEnabled)
            {
                if ((StartThumb != null && StartThumb.IsMouseOver) || (EndThumb != null && EndThumb.IsMouseOver))
                    return;

                var point = e.GetPosition(SliderContainer);
                if (e.ChangedButton == MouseButton.Left)
                {
                    MoveBlockTo(point, SliderThumb.Start);
                }
                else if (e.ChangedButton == MouseButton.Right)
                {
                    MoveBlockTo(point, SliderThumb.End);
                }

                e.Handled = true;
            }
        }

        private void MoveBlockTo(Point point, SliderThumb block)
        {
            double position;
            if (Orientation == Orientation.Horizontal) position = point.X;
            else position = point.Y;

            double viewportSize = (Orientation == Orientation.Horizontal) ? SliderContainer.ActualWidth : SliderContainer.ActualHeight;
            if (!double.IsNaN(viewportSize) && viewportSize > 0)
            {
                var value = Math.Min(Maximum, Minimum + (position / viewportSize) * (Maximum - Minimum));
                if (block == SliderThumb.Start)
                {
                    Start = value;
                }
                else if (block == SliderThumb.End)
                {
                    End = Math.Max(Start, value);
                }
            }
        }

        private static void OnDragStartedEvent(object sender, DragStartedEventArgs e)
        {
            if (sender is RangeSlider rs)
            {
                rs.OnDragStartedEvent(e);
            }
        }

        private void OnDragStartedEvent(DragStartedEventArgs e)
        {
        }

        private static void OnThumbDragDelta(object sender, DragDeltaEventArgs e)
        {
            if (sender is RangeSlider rs)
            {
                rs.OnThumbDragDelta(e);
            }
        }

        private void OnThumbDragDelta(DragDeltaEventArgs e)
        {
            if (!IsReadOnly && e.OriginalSource is Thumb thumb && SliderContainer != null)
            {
                double change;
                if (Orientation == Orientation.Horizontal)
                {
                    change = e.HorizontalChange / SliderContainer.ActualWidth * (Maximum - Minimum);
                }
                else
                {
                    change = e.VerticalChange / SliderContainer.ActualHeight * (Maximum - Minimum);
                }

                if (thumb == StartThumb)
                {
                    if (Start + change > Maximum)
                    {
                        Start = Maximum;
                    }
                    else
                    {
                        Start = Math.Max(Minimum, Start + change);
                    }
                }
                else if (thumb == EndThumb)
                {
                    End = Math.Min(Maximum, Math.Max(Start, End + change));
                }
            }
        }

        private static void OnDragCompletedEvent(object sender, DragCompletedEventArgs e)
        {
            if (sender is RangeSlider rs)
            {
                rs.OnDragCompletedEvent(e);
            }
        }

        private void OnDragCompletedEvent(DragCompletedEventArgs e)
        {
        }
    }
}
