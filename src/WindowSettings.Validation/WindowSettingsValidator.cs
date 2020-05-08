using System;

namespace WindowSettings.Validation
{
    public class WindowSettingsValidator
    {
        public static string ValidateWindowValue(string _start, string _digits)
        {
            if (!string.IsNullOrEmpty(_start))
            {
                var startValue = Convert.ToDecimal(_start);
                if (!string.IsNullOrEmpty(_digits) && Convert.ToInt32(_digits) <= 16 && startValue >= 0)
                {
                    _start = Convert.ToString(Math.Round(Convert.ToDecimal(_start), Convert.ToInt32(_digits)));
                }
            }
            return _start;
        }

        public static (string Maximum, string Minimum, string Start) ValidateWindowDigits(string _digits, string _maximum, string _minimum, string _start)
        {
            string Maximum = string.Empty; string Minimum = string.Empty; string Start = string.Empty;
            if (!string.IsNullOrEmpty(_digits) && Convert.ToInt32(_digits) <= 16)
            {
                Maximum = Convert.ToString(Math.Round(Convert.ToDecimal(_maximum), Convert.ToInt32(_digits)));
                Minimum = Convert.ToString(Math.Round(Convert.ToDecimal(_minimum), Convert.ToInt32(_digits)));
                Start = Convert.ToString(Math.Round(Convert.ToDecimal(_start), Convert.ToInt32(_digits)));
            }
            return (Maximum, Minimum, Start);
        }
    }
}

