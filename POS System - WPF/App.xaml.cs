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
        protected override void OnStartup(StartupEventArgs e)
        {
            var loginVM = new LoginWindowView();
            loginVM.Show();
        }

    }
}
