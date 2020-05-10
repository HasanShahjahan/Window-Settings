using System.Windows;
using WindowSettings.App.ViewModels;
using WindowSettings.Business.Managers;
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
        private readonly WindowSettingsManager _windowSettingsManager;

        public MainWindow(IInputValidator inputValidator, WindowSettingsManager windowSettingsManager)
        {
            _inputValidator = inputValidator;
            _windowSettingsManager = windowSettingsManager;
            InitializeComponent();
            var model = new MainViewModel("Md Shahjahan Miah", "2", "7.89", "1.45", "3.50", "7.89", true, RoundingType.Double, _inputValidator);
            DataContext = model;
        }
    }
}
