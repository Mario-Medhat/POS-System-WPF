using POS_System___WPF.Commands;
using POS_System___WPF.Models;
using POS_System___WPF.Repositories.Interfaces;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

namespace POS_System___WPF.ViewModels
{
    /// <summary>
    /// ViewModel responsible for POS screen logic:
    /// - Loading products
    /// - Managing cart items
    /// - Calculating totals
    /// </summary>
    public class SalesViewModel : INotifyPropertyChanged
    {
        private readonly IProductRepository _productRepository;

        private Product _selectedProduct;
        private int _quantity = 1;

        /// <summary>
        /// List of all available products.
        /// Loaded once at startup.
        /// </summary>
        public ObservableCollection<Product> Products { get; }

        /// <summary>
        /// The shopping cart items. Updated every time a user adds/removes a product.
        /// </summary>
        public ObservableCollection<SaleItem> Cart { get; }

        /// <summary>
        /// Product currently selected in the UI.
        /// </summary>
        public Product SelectedProduct
        {
            get => _selectedProduct;
            set => SetProperty(ref _selectedProduct, value);
        }

        /// <summary>
        /// Quantity for the selected product.
        /// </summary>
        public int Quantity
        {
            get => _quantity;
            set => SetProperty(ref _quantity, value);
        }

        // Commands
        public ICommand AddToCartCommand { get; }
        public ICommand RemoveItemCommand { get; }

        public SalesViewModel(IProductRepository productRepository)
        {
            // Dependency Injection: no concrete repository inside the ViewModel.
            _productRepository = productRepository;

            Products = new ObservableCollection<Product>();
            Cart = new ObservableCollection<SaleItem>();

            // Commands
            AddToCartCommand = new RelayCommand(AddToCart, CanAddToCart);
            RemoveItemCommand = new RelayCommand(RemoveItem, CanRemoveItem);

            // Whenever the cart changes, update TotalAmount automatically.
            Cart.CollectionChanged += (_, __) => OnPropertyChanged(nameof(TotalAmount));
        }

        /// <summary>
        /// Loads products from the database on startup.
        /// </summary>
        public async Task InitializeAsync()
        {
            var products = await _productRepository.GetAllAsync();

            Products.Clear();
            foreach (var product in products)
                Products.Add(product);
        }

        /// <summary>
        /// Checks if user can add item to cart (product selected & qty valid).
        /// </summary>
        private bool CanAddToCart() =>
            SelectedProduct != null && Quantity > 0;

        /// <summary>
        /// Adds the selected product to the cart.
        /// </summary>
        private void AddToCart()
        {
            var item = new SaleItem
            {
                Product = SelectedProduct,
                PriceAtSaleTime = SelectedProduct.Price,
                Quantity = Quantity
            };
            Console.Write(item.TotalAmount);
            Cart.Add(item);
        }

        /// <summary>
        /// Checks if cart is not empty.
        /// </summary>
        private bool CanRemoveItem() =>
            Cart.Count > 0;

        /// <summary>
        /// Removes the last added item from the cart.
        /// </summary>
        private void RemoveItem()
        {
            Cart.RemoveAt(Cart.Count - 1);
        }

        /// <summary>
        /// Total price of all items in the cart.
        /// </summary>
        public decimal TotalAmount =>
            Cart.Sum(i => i.TotalAmount);

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
