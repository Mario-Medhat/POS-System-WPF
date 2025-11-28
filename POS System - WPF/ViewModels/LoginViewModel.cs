using POS_System___WPF.Commands;
using POS_System___WPF.Models;
using POS_System___WPF.Interfaces;
using POS_System___WPF.Services;
using POS_System___WPF.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace POS_System___WPF.ViewModels
{
    internal class LoginViewModel : INotifyPropertyChanged
    {
        private string _username;
        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public RelayCommand LoginCommand { get; }

        private readonly IAuthService _authService;

        public LoginViewModel(IAuthService authService)
        {
            _authService = authService;
            LoginCommand = new RelayCommand(async () => await Login());
            
        }

        private async Task Login()
        {
            bool isValid = await _authService.Login(Username, Password);

            if (isValid)
            {
                // open the main window
                App.Current.MainWindow = new MainWindow();
                App.Current.MainWindow.Show();

                // close login window
                Application.Current.Windows
                    .OfType<LoginWindowView>()
                    .FirstOrDefault()?.Close();
            }
            else
            {
                MessageBox.Show("Wrong username or password");
            }
        }


        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises UI updates for property changes.
        /// </summary>
        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        /// <summary>
        /// Reusable helper to change field value + notify UI.
        /// </summary>
        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string name = "")
        {
            if (Equals(field, value)) return false;

            field = value;
            OnPropertyChanged(name);
            return true;
        }
    }
}
