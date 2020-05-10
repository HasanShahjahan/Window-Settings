using WindowSettings.Common.Enums;
using WindowSettings.DataObjects.Model;

namespace WindowSettings.DataObjects.Mappers
{
    public static class WindowSettingsMapper
    {
        public static Entities.Settings.WindowSettings ToCommand(this WindowSettingsDto model)
        {
            return new Entities.Settings.WindowSettings()
            { 
                Name = model.Name,
                RoundingType = RoundingType.Double.ToString(),
                Digits = model.Digits,
                Value = model.Value,
                Minimum = model.Minimum,
                Maximum = model.Maximum
            };
        }
        public static WindowSettingsDto ToQueries(this Entities.Settings.WindowSettings model)
        {
            return new WindowSettingsDto()
            {
                Name = model.Name,
                RoundingType = model.RoundingType,
                Digits = model.Digits,
                Value = model.Value,
                Minimum = model.Minimum,
                Maximum = model.Maximum
            };
        }
    }
}
