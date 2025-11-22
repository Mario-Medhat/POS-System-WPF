using POS_System___WPF.Commands;
using POS_System___WPF.Services;
using POS_System___WPF.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace POS_System___WPF.ViewModels
{
    internal class HomeViewModel : INotifyPropertyChanged
    {
        private UserControl _activeView;
        public UserControl ActiveView
        {
            get { return _activeView; }
            set { SetProperty(ref _activeView, value); }
        }

        private SalesView _salesView;
        public SalesView SalesView
        {
            get
            {
                if (_salesView == null)
                    _salesView = new SalesView();
                return _salesView;
            }
        }

        private ReportsView _reportsView;
        public ReportsView ReportsView
        {
            get
            {
                if (_reportsView == null)
                    _reportsView = new ReportsView();
                return _reportsView;
            }
        }

        private UserManagementView _userManagementView;
        public UserManagementView UserManagementView
        {
            get
            {
                if (_userManagementView == null)
                    _userManagementView = new UserManagementView();
                return _userManagementView;
            }
        }

        private InventoryManagementView _inventoryManagementViewModel;
        public InventoryManagementView InventoryManagementView
        {
            get
            {
                if (_inventoryManagementViewModel == null)
                    _inventoryManagementViewModel = new InventoryManagementView();
                return _inventoryManagementViewModel;
            }
        }


        public RelayCommand ShowSalesViewCommand { get; }
        public RelayCommand ShowReportsViewCommand { get; }
        public RelayCommand ShowUserManagementViewCommand { get; }
        public RelayCommand ShowInventoryManagementViewCommand { get; }


        //Constructor
        public HomeViewModel()
        {
            ShowSalesViewCommand = new RelayCommand(() => ActiveView = SalesView);
            ShowReportsViewCommand = new RelayCommand(() => ActiveView = ReportsView);
            ShowUserManagementViewCommand = new RelayCommand(() => ActiveView = UserManagementView);
            ShowInventoryManagementViewCommand = new RelayCommand(() => ActiveView = InventoryManagementView);
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
