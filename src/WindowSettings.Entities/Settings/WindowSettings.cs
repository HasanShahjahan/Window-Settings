using WindowSettings.Common.Enums;
using WindowSettings.Entities.Base;

namespace WindowSettings.Entities.Settings
{
    public class WindowSettings : EntityBase
    {
        public string Name { get; set; }

        public string RoundingType { get; set; }

        public string Digits { get; set; }

        public string Minimum { get; set; }

        public string Value { get; set; }

        public string Maximum { get; set; }

        
        
    }
}
