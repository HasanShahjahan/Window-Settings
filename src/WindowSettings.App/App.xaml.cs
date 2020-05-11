using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows;
using WindowSettings.App.ViewModels;
using WindowSettings.Business.Interfaces;
using WindowSettings.Business.Managers;
using WindowSettings.DataAccess.DbContext;
using WindowSettings.DataAccess.Repositories;
using WindowSettings.Validation;

namespace WindowSettings.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost host;
        public static IServiceProvider ServiceProvider { get; private set; }

        public App()
        {
            host = Host.CreateDefaultBuilder().ConfigureAppConfiguration((context, builder) =>
                    {
                        builder.AddJsonFile("appsettings.json", optional: true);
                    }).ConfigureServices((context, services) =>
                    {
                        ConfigureServices(context.Configuration, services);
                    })
                    .ConfigureLogging(logging =>
                    {
                        
                    })
                    .Build();

            ServiceProvider = host.Services;
        }

        private void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            services.AddSingleton<MainViewModel>();
            services.AddTransient<MainWindow>();
            services.AddTransient<IInputValidator, WindowSettingsValidator>();
            services.AddTransient<WindowSettingsRepository, WindowSettingsRepository>();
            services.AddTransient<IWindowSettingsManager, WindowSettingsManager>();
            services.AddDbContext<EliseDbContext>(options => options.UseInMemoryDatabase("EliseDbContext"));

        }

        public void Configure(IApplicationBuilder app)
        {
            
            // your logic goes here
        }
        //Startup Event
        protected override async void OnStartup(StartupEventArgs e)
        {
            await host.StartAsync();
            var window = ServiceProvider.GetRequiredService<MainWindow>();
            window.Show();
            base.OnStartup(e);
        }

        //Exit Event
        protected override async void OnExit(ExitEventArgs e)
        {
            using (host) await host.StopAsync(TimeSpan.FromSeconds(5));
            base.OnExit(e);
        }
    }
}
