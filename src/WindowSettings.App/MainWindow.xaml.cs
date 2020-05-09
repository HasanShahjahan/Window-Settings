using System.Windows;
using WindowSettings.App.ViewModels;
using WindowSettings.Common.Enums;
using WindowSettings.Validation;

namespace WindowSettings.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IInputValidator _inputValidator;

        public MainWindow(IInputValidator inputValidator)
        {
            _inputValidator = inputValidator;
            InitializeComponent();
            var model = new MainViewModel("Md Shahjahan Miah", "2", "7.89", "1.45", "3.50", "7.89", true, RoundingType.Double, _inputValidator);
            DataContext = model;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
