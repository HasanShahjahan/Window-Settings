using System;
using System.Linq;

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
                        result = "Custom Name can't be empty";
                    }
                    break;

                case "Minimum":
                    if (string.IsNullOrWhiteSpace(minimum))
                    {
                        result = "Minimum can't be empty";
                    }
                    else if (Convert.ToDecimal(minimum) > Convert.ToDecimal(maximum))
                    {
                        result = "Minium value can't exceed Maximum value.";
                    }
                    break;

                case "Maximum":
                    if (string.IsNullOrWhiteSpace(maximum))
                    {
                        result = "Maximum can't be empty";
                    }
                    else if (Convert.ToDecimal(minimum) > Convert.ToDecimal(maximum))
                    {
                        result = "Maximum value can't be smaller than Minimum value.";
                    }
                    break;

                case "Start":
                    if (string.IsNullOrWhiteSpace(start))
                    {
                        result = "Value can't be empty.";
                    }
                    else if (Convert.ToDecimal(start) < Convert.ToDecimal(minimum) || Convert.ToDecimal(start) > Convert.ToDecimal(maximum))
                    {
                        result = "Value can't be outside minimum or maximum.";
                    }
                    break;

                case "Digits":
                    if (isDecimalValue && string.IsNullOrWhiteSpace(digits))
                    {
                        result = "Digits can't be empty";
                    }
                    else if (!digits.All(char.IsDigit))
                    {
                        result = "Fraction value is not allowed.";
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

