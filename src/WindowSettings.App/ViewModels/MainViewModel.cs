using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Input;
using WindowSettings.Common.Command;
using WindowSettings.Validation;

namespace WindowSettings.App.ViewModels
{
    public class MainViewModel : ValidationRule, INotifyPropertyChanged
    {
        private string _name;
        private string _digits;
        private string _maximum;
        private string _minimum;
        private string _start;
        private string _end;
        private string _errorMessage;
        private bool _isDecimalValue;
        private string _myCommandValue;
        public ICommand MyCommand { get; set; }

        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyRaised("Name"); }
        }

        public string Digits
        {
            get { return _digits; }
            set
            {
                _digits = value;
                (Maximum, Minimum, Start) = WindowSettingsValidator.ValidateWindowDigits(value, _maximum, _minimum, _start);
                OnPropertyRaised("Digits");
            }
        }

        public string Maximum
        {
            get { return _maximum; }
            set { _maximum = value; OnPropertyRaised("Maximum"); OnPropertyRaised("End"); }
        }

        public string Minimum
        {
            get { return _minimum; }
            set
            {
                _minimum = value;
                OnPropertyRaised("Minimum");
            }
        }

        public string Start
        {
            get { return _start; }
            set
            {
                _start = WindowSettingsValidator.ValidateWindowValue(value, _digits);
                OnPropertyRaised("Start");
            }
        }

        public string End
        {
            get { return _end; }
            set { _end = value; OnPropertyRaised("End"); }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; }
        }

        public bool IsDecimalValue
        {
            get
            {
                bool selected = _isDecimalValue ? true : false;
                return selected;
            }
            set { OnPropertyRaised("IsDecimalValue"); }
        }

        public string MyCommandValue
        {
            get { return _myCommandValue; }
            set
            {
                _myCommandValue = value;
                if (!string.IsNullOrEmpty(_myCommandValue))
                {
                    if (_myCommandValue == "Z") _isDecimalValue = false;
                    else _isDecimalValue = true;
                    Name = "Z";
                }
                OnPropertyRaised("MyCommandValue");
            }

        }

        public MainViewModel(string name, string digits, string maximum, string minimum, string start, string end, bool isDecimalValue, string myCommandValue)
        {
            _name = name;
            _digits = digits;
            _maximum = maximum;
            _minimum = minimum;
            _start = start;
            _end = end;
            _isDecimalValue = isDecimalValue;
            _myCommandValue = myCommandValue;
            MyCommand = new RelayCommand(ExecuteMethod, CanExecuteMethod);
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyRaised(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        private bool CanExecuteMethod(object parameter)
        {
            if (parameter != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ExecuteMethod(object parameter)
        {
            MyCommandValue = (string)parameter;
            if (MyCommandValue == "Z") _isDecimalValue = false;
            else _isDecimalValue = true;
            OnPropertyRaised("IsDecimalValue");
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            ValidationResult result = new ValidationResult(true, null);
            string inputString = (value ?? string.Empty).ToString();
            if (string.IsNullOrEmpty(inputString))
                return result;
            if (Convert.ToDecimal(inputString) < Convert.ToDecimal(Minimum) || Convert.ToDecimal(inputString) > Convert.ToDecimal(Maximum))
                result = new ValidationResult(false, this.ErrorMessage);
            return result;
        }
    }
}
