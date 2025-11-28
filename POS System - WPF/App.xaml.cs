using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using POS_System___WPF.Interfaces;
using POS_System___WPF.Repositories;
using POS_System___WPF.Services;
using POS_System___WPF.ViewModels;
using POS_System___WPF.Views;
using System.Configuration;
using System.Data;
using System.Windows;

namespace POS_System___WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IHost? _host;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // تمنع تشغيل الـ host في وضع الـ designer
            if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                return;

            _host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    // ======= register your services =======
                    services.AddSingleton<IMessageService, MessageService>();
                    services.AddSingleton<IPrintService, PrintService>();
                    services.AddSingleton<IBarcodeService, BarcodeService>();
                    services.AddSingleton<IExportService, ExportService>();

                    // register ViewModels (transient or singleton as you prefer)
                    services.AddTransient<LoginViewModel>();

                    // register Windows so DI resolves their constructors
                    services.AddTransient<LoginWindowView>();
                })
                .Build();

            // create and show main window resolved from DI
            var loginVM = _host.Services.GetRequiredService<LoginWindowView>();
            loginVM.Show();
        }
        protected override async void OnExit(ExitEventArgs e)
        {
            if (_host is not null)
            {
                await _host.StopAsync();
                _host.Dispose();
            }
            base.OnExit(e);
        }
    }
}
