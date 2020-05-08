namespace WindowSettings.Common.Enums
{
    public sealed class DependencyPropertyType : StringEnum
    {
        public DependencyPropertyType(string value) : base(value)
        {
        }
        public const string MinimumProperty = "Minimum";
        public const string MaximumProperty = "Maximum";
        public const string ValueProperty = "Value";
        public const string StarProperty = "Start";
        public const string EndProperty = "End";
        public const string Orientation = "Orientation";
        public const string IsMoveToPointEnabled = "IsMoveToPointEnabled";
        public const string StartThumbToolTip = "StartThumbToolTip";
        public const string EndThumbToolTip = "EndThumbToolTip";
        public const string StartThumbStyle = "StartThumbStyle";
        public const string EndThumbStyle = "EndThumbStyle";
        public const string IsReadOnly = "IsReadOnly";
        public const string PART_SliderContainer = "PART_SliderContainer";
        public const string PART_StartArea = "PART_StartArea";
        public const string PART_EndArea = "PART_EndArea";
        public const string PART_StartThumb = "PART_StartThumb";
        public const string PART_EndThumb = "PART_EndThumb";
    }
}

