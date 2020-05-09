using System;
using System.Collections.Generic;
using System.Text;

namespace WindowSettings.Validation
{
    public interface IInputValidator
    {
        string ValidateInput(string inputName, string name, string minimum, string maximum, string digits, string start, bool isDecimalValue);
        string ValidateWindowValue(string _start, string _digits, bool isDecimal);
        (string Maximum, string Minimum, string Start) ValidateWindowDigits(string _digits, string _maximum, string _minimum, string _start);
    }
}
