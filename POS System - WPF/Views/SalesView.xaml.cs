using POS_System___WPF.Repositories;
using POS_System___WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace POS_System___WPF.Views
{
    /// <summary>
    /// Interaction logic for SalesView.xaml
    /// </summary>
    public partial class SalesView : UserControl
    {
        private bool _wasLoadedBefor = false;
        public SalesView()
        {
            InitializeComponent();
            // Using Loaded event ensures the view is fully created 
            // before running any async initialization.
            Loaded += SalesView_Loaded;
        }


        /// <summary>
        /// Runs once when the view finishes loading.
        /// Creates and initializes the ViewModel asynchronously.
        /// </summary>
        private async void SalesView_Loaded(object sender, RoutedEventArgs e)
        {
            if (!_wasLoadedBefor)
            {
                try
                {
                    // Create the repository (this should ideally be done using DI Container)
                    var appDbContext = new Data.AppDbContext();
                    var productRepository = new ProductRepository(appDbContext);

                    // Pass repository into the ViewModel
                    var viewModel = new SalesViewModel(productRepository);

                    // Load necessary data (products)
                    await viewModel.InitializeAsync();

                    // Bind UI to ViewModel
                    DataContext = viewModel;

                    // Mark as loaded to prevent re-initialization
                    _wasLoadedBefor = true;
                }
                catch (Exception ex)
                {
                    // Fail-safe UI message if something goes wrong
                    MessageBox.Show(
                        $"Failed to load application data.\n\nError: {ex.Message}",
                        "Initialization Error",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error
                    );
                }
            }
        }
    }
}
