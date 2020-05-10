using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using WindowSettings.App.ViewModels;
using WindowSettings.Business.Managers;
using WindowSettings.Common.Enums;
using WindowSettings.DataObjects.Model;
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
        private async void Save(object sender, RoutedEventArgs e)
        {

            #region If Needed
            //TODO : We have to implement the way we want to save 
            //TODO : Get Application object and map to DTOs.


            // Caution : When below comment will be uncommented then this object will be saved in InMemory Database by EntityFramework Core

            //var model = new WindowSettingsDto()
            //{
            //    Name = "Md Shahjahan Miah",
            //    RoundingType = "Q",
            //    Digits = "2",
            //    Minimum = "1.00",
            //    Value = "1.50",
            //    Maximum = "2.00"
            //};
            //await _windowSettingsManager.CreateWindowSettingsAsync(model);
            #endregion

        }
    }
}
