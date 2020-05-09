using System;
using System.Linq;
using WindowSettings.Utilities;

namespace WindowSettings.Validation
{
    public class WindowSettingsValidator : IInputValidator
    {
        public string ValidateInput(string inputName, string name, string minimum, string maximum, string digits, string start, bool isDecimalValue)
        {
            string result = null;
            switch (inputName)
            {
                case "Name":
                    if (string.IsNullOrWhiteSpace(name))
                    {
                        result = string.Format(ResourceFile.CanNotBeEmpty, "Custom Name");
                    }
                    break;

                case "Minimum":
                    if (string.IsNullOrWhiteSpace(minimum))
                    {
                        result = string.Format(ResourceFile.CanNotBeEmpty, "Minimum");
                    }
                    else if (Convert.ToDecimal(minimum) > Convert.ToDecimal(maximum))
                    {
                        result = string.Format(ResourceFile.CanNotExceed, "Minimum", "Maximum");
                    }
                    break;

                case "Maximum":
                    if (string.IsNullOrWhiteSpace(maximum))
                    {
                        result = string.Format(ResourceFile.CanNotBeEmpty, "Maximum");
                    }
                    else if (Convert.ToDecimal(minimum) > Convert.ToDecimal(maximum))
                    {
                        result = string.Format(ResourceFile.ValueCanNotBeSmallerThan, "Maximum", "Minimum");
                    }
                    break;

                case "Start":
                    if (string.IsNullOrWhiteSpace(start))
                    {
                        result = string.Format(ResourceFile.CanNotBeEmpty, "Value");
                    }
                    else if (Convert.ToDecimal(start) < Convert.ToDecimal(minimum) || Convert.ToDecimal(start) > Convert.ToDecimal(maximum))
                    {
                        result = string.Format(ResourceFile.ValueCanNotBeOutside, "Minimum", "Maximum");
                    }
                    break;

                case "Digits":
                    if (isDecimalValue && string.IsNullOrWhiteSpace(digits))
                    {
                        result = string.Format(ResourceFile.CanNotBeEmpty, "Digits");
                    }
                    else if (!digits.All(char.IsDigit))
                    {
                        result = string.Format(ResourceFile.IsNotAllowed,"Fraction");
                    }
                    break;
            }

            return result;
        }

        public string ValidateWindowValue(string _start, string _digits)
        {
            if (!string.IsNullOrWhiteSpace(_start))
            {
                var startValue = Convert.ToDecimal(_start);
                if (!string.IsNullOrEmpty(_digits) && Convert.ToInt32(_digits) <= 16 && startValue >= 0)
                {
                    _start = Convert.ToString(Math.Round(Convert.ToDecimal(_start), Convert.ToInt32(_digits)));
                }
            }
            return _start;
        }

        public (string Maximum, string Minimum, string Start) ValidateWindowDigits(string _digits, string _maximum, string _minimum, string _start)
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

