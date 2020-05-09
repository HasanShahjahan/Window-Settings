using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using WindowSettings.Common.Command;
using WindowSettings.Common.Enums;
using WindowSettings.Common.Event;
using WindowSettings.Validation;

namespace WindowSettings.App.ViewModels
{
    public class MainViewModel : ObservableEvent, IDataErrorInfo
    {
        private string _name;

        private string _digits;

        private string _maximum;

        private string _minimum;

        private string _start;

        private string _end;

        private bool _isDecimalValue;

        private string _myCommandValue;

        public ICommand MyCommand { get; set; }

        public string Error { get { return null; } }

        public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();
        
        private readonly IInputValidator _inputValidator;

        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged("Name"); }
        }

        public string Digits
        {
            get { return _digits; }
            set
            {
                _digits = value;
                (Maximum, Minimum, Start) = _inputValidator.ValidateWindowDigits(value, _maximum, _minimum, _start, _isDecimalValue);
                OnPropertyChanged("Digits");
            }
        }

        public string Maximum
        {
            get { return _maximum; }
            set 
            { 
                _maximum = value; 
                OnPropertyChanged("Maximum"); 
                OnPropertyChanged("End"); 
            }
        }

        public string Minimum
        {
            get { return _minimum; }
            set
            {
                _minimum = value;
                OnPropertyChanged("Minimum");
            }
        }

        public string Start
        {
            get { return _start; }
            set
            {
                _start = _inputValidator.ValidateWindowValue(value, _digits, _isDecimalValue);
                OnPropertyChanged("Start");
            }
        }

        public string End
        {
            get { return _end; }
            set { _end = value; OnPropertyChanged("End"); }
        }

        public bool IsDecimalValue
        {
            get
            {
                bool selected = _isDecimalValue ? true : false;
                return selected;
            }
            set { OnPropertyChanged("IsDecimalValue"); }
        }

        public string MyCommandValue
        {
            get { return _myCommandValue; }
            set
            {
                _myCommandValue = value;

                if (RoundingType.Integer == value)
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
                OnPropertyChanged("MyCommandValue");
            }

        }

        public MainViewModel(string name, string digits, string maximum, string minimum, string start, string end, bool isDecimalValue, string myCommandValue, IInputValidator inputValidator)
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
            _inputValidator = inputValidator;
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
            if (MyCommandValue == RoundingType.Integer) _isDecimalValue = false;
            //if (MyCommandValue == RoundingType.Integer && string.IsNullOrEmpty(_digits)) 
            //{
            //    _isDecimalValue = false;
            //    Digits = "2";
            //} 
            else _isDecimalValue = true;
            OnPropertyChanged("IsDecimalValue");
        }

        public string this[string name]
        {
            get
            {
                string result = _inputValidator.ValidateInput(name, Name, Minimum, Maximum, Digits, Start, IsDecimalValue);
                if (ErrorCollection.ContainsKey(name)) ErrorCollection[name] = result;
                else if (result != null) ErrorCollection.Add(name, result);
                OnPropertyChanged("ErrorCollection");
                return result;
            }
        }
    }
}
