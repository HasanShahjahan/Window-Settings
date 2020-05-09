using System;
using System.Linq;
using System.Windows.Navigation;
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
                    else if (string.IsNullOrWhiteSpace(maximum))
                    {
                        break;
                    }
                    else if (!ValidNumber(minimum, isDecimalValue))
                    {
                        var value = isDecimalValue ? "Double" : "Integer";
                        result = "Given input should be " + value + ".";
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
                    else if (string.IsNullOrWhiteSpace(minimum))
                    {
                        break;
                    }
                    else if (!ValidNumber(maximum, isDecimalValue))
                    {
                        var value = isDecimalValue ? "Double" : "Integer";
                        result = "Given input should be " + value + ".";
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
                    else if (string.IsNullOrWhiteSpace(minimum))
                    {
                        break;
                    }
                    else if (string.IsNullOrWhiteSpace(maximum))
                    {
                        break;
                    }
                    else if (!ValidNumber(start, isDecimalValue))
                    {
                        var value = isDecimalValue ? "Double" : "Integer";
                        result = "Given input should be " + value + ".";
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
                        result = string.Format(ResourceFile.IsNotAllowed);
                    }
                    break;
            }
            return result;
        }

        public string ValidateWindowValue(string _start, string _digits, bool isDecimal)
        {
            if (!string.IsNullOrWhiteSpace(_start))
            {
                if (double.TryParse(_start, out double _) || int.TryParse(_start, out int _))
                {
                    if (isDecimal)
                    {
                        var startValue = Convert.ToDecimal(_start);
                        if (!string.IsNullOrWhiteSpace(_digits) && !string.IsNullOrEmpty(_digits) && int.TryParse(_digits, out int _) && Convert.ToInt32(_digits) <= 16 && startValue >= 0)
                        {
                            _start = Convert.ToString(Math.Round(Convert.ToDecimal(_start), Convert.ToInt32(_digits)));
                        }
                    }
                    else
                    {
                        int start = (int)Math.Round(Convert.ToDecimal(_start));
                        _start = Convert.ToString(start);
                    }
                }
            }
            return _start;
        }

        public (string Maximum, string Minimum, string Start) ValidateWindowDigits(string _digits, string _maximum, string _minimum, string _start, bool isDecimalValue)
        {
            string Maximum = string.Empty; string Minimum = string.Empty; string Start = string.Empty;
            if (string.IsNullOrWhiteSpace(_digits)  || !int.TryParse(_digits, out int _) || Convert.ToInt32(_digits) >= 16)
            {
                Maximum = _maximum;
                Minimum = _minimum;
                Start = _start;
                return (Maximum, Minimum, Start);
            }

            if (!isDecimalValue)
            {
                if (!string.IsNullOrEmpty(_minimum))
                {
                    int minimum = (int)Math.Round(Convert.ToDecimal(_minimum));
                    Minimum = Convert.ToString(minimum);
                }
                if (!string.IsNullOrEmpty(_start))
                {
                    int start = (int)Math.Round(Convert.ToDecimal(_start));
                    Start = Convert.ToString(start);
                }
                if (!string.IsNullOrEmpty(_maximum))
                {
                    int maximum = (int)Math.Round(Convert.ToDecimal(_maximum));
                    Maximum = Convert.ToString(maximum);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(_minimum) && !string.IsNullOrEmpty(_digits))
                {
                    double minimum = Math.Round(Convert.ToDouble(_minimum), Convert.ToInt32(_digits), MidpointRounding.ToEven);
                    Minimum = Convert.ToString(minimum);
                }
                if (!string.IsNullOrEmpty(_start) && !string.IsNullOrEmpty(_digits))
                {
                    double start = Math.Round(Convert.ToDouble(_start), Convert.ToInt32(_digits), MidpointRounding.ToEven);
                    Start = Convert.ToString(start);
                }
                if (!string.IsNullOrEmpty(_maximum) && !string.IsNullOrEmpty(_digits))
                {
                    double maximum = Math.Round(Convert.ToDouble(_maximum), Convert.ToInt32(_digits), MidpointRounding.ToEven);
                    Maximum = Convert.ToString(maximum);
                }
            }
            return (Maximum, Minimum, Start);
        }

        private bool ValidNumber(string value, bool isDecimalValue)
        {
            bool result = isDecimalValue ? double.TryParse(value, out double _) : int.TryParse(value, out int _);
            return result;
        }

    }
}

