using POS_System___WPF.Repositories;
using POS_System___WPF.ViewModels;
using POS_System___WPF.Views;
using System;
using System.Windows;

namespace POS_System___WPF
{
    /// <summary>
    /// Main application window.
    /// Responsible ONLY for:
    /// - Initializing UI components
    /// - Creating the ViewModel
    /// - Setting DataContext
    /// 
    /// All business logic stays in the ViewModel.
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainContentControl.Content = new HomeView();
        }
    }
}