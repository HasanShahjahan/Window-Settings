using WindowSettings.Common.Enums;
using WindowSettings.DataObjects.Base;

namespace WindowSettings.DataObjects.Model
{
    public class WindowSettingsDto : BaseDto
    {
        public string Name { get; set; }

        public string RoundingType { get; set; }

        public string Digits { get; set; }

        public string Minimum { get; set; }

        public string Value { get; set; }

        public string Maximum { get; set; }
    }
}
