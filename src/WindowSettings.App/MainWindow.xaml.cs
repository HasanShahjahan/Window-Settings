using System.Windows;
using WindowSettings.App.ViewModels;
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
            var model = new MainViewModel("Md Shahjahan Miah","2","2.00","1","1.50","2",true,"Q", _inputValidator);
            DataContext = model;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
